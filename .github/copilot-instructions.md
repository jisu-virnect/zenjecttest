# GitHub Copilot Instructions

## Project Overview
This is a Unity project using Zenject (Extenject) for dependency injection.
We prioritize clean architecture, testability, and maintainability over quick hacks.

## Code Style Guidelines

### C# Naming Conventions (Standard)
- **Classes, Interfaces, Structs, Enums**: PascalCase (e.g., `PlayerController`, `IGameService`)
- **Methods, Properties, Events**: PascalCase (e.g., `GetHealth()`, `IsAlive`)
- **Public Fields**: PascalCase (e.g., `MaxHealth`)
- **Private/Protected Fields**: camelCase with underscore prefix (e.g., `_currentHealth`, `_isDead`)
- **Local Variables, Parameters**: camelCase (e.g., `playerData`, `isValid`)
- **Constants**: PascalCase or UPPER_CASE (e.g., `MaxPlayers` or `MAX_PLAYERS`)
- **Interface Prefix**: Always use `I` prefix (e.g., `IPlayerService`, `IRepository`)

### Unity-Specific Conventions
- Add `[SerializeField]` attribute for private fields that need to be visible in Inspector
- Use `[Header("Section Name")]` and `[Tooltip("Description")]` for better Inspector organization
- Avoid public fields unless specifically needed for Inspector; prefer properties
- Use `#region` blocks to organize code sections when appropriate (but don't overuse)

## Architecture Principles

### Layer Separation (Critical)
```
┌─────────────────────────┐
│   Presentation Layer    │  ← MonoBehaviour (View only)
├─────────────────────────┤
│    Business Logic       │  ← Plain C# classes (POCO)
├─────────────────────────┤
│    Data Layer           │  ← Models, DTOs, Repositories
└─────────────────────────┘
```

- **MonoBehaviour = View Layer ONLY**: Handle Unity lifecycle, rendering, input forwarding
- **Business Logic = Plain C# (POCO)**: All game rules, calculations, state management
- **This separation enables unit testing without Unity Editor**

### Dependency Injection (Zenject/Extenject)

#### Injection Priority (Follow this order)
1. **Constructor Injection** (Primary, Always prefer this)
   ```csharp
   public class PlayerService : IPlayerService
   {
       private readonly IHealthSystem _healthSystem;
       private readonly IScoreSystem _scoreSystem;
       
       public PlayerService(IHealthSystem healthSystem, IScoreSystem scoreSystem)
       {
           _healthSystem = healthSystem;
           _scoreSystem = scoreSystem;
       }
   }
   ```

2. **Field/Property Injection** (Only for MonoBehaviour when constructor injection is impossible)
   ```csharp
   public class PlayerView : MonoBehaviour
   {
       [Inject] private IPlayerService _playerService;
   }
   ```

3. **NEVER use `Container.Resolve()` directly** (Service Locator anti-pattern)

#### Installer Best Practices
- Create installers per feature/domain, not one giant installer
- Inherit from `MonoInstaller` (scene-based) or `ScriptableObjectInstaller` (project-wide)
- Use descriptive binding methods:
  - `AsSingle()`: Singleton (same instance)
  - `AsTransient()`: New instance per injection
  - `FromInstance(obj)`: Use existing instance
  - `FromComponentInHierarchy()`: Find in scene
  - `FromNew()`: Create new instance
- Keep `InstallBindings()` method clean and readable

Example:
```csharp
public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IPlayerService>().To<PlayerService>().AsSingle();
        Container.Bind<IHealthSystem>().To<HealthSystem>().AsSingle();
        Container.BindInterfacesTo<PlayerInitializer>().AsSingle();
    }
}
```

## SOLID Principles

- **Single Responsibility**: One class, one reason to change
- **Open/Closed**: Open for extension, closed for modification (use interfaces)
- **Liskov Substitution**: Derived classes must be substitutable for their base
- **Interface Segregation**: Many specific interfaces > one general interface
- **Dependency Inversion**: Depend on abstractions, not concretions

## Performance Guidelines

### Avoid Common Performance Pitfalls
- **NEVER** call `GetComponent<T>()`, `Find()`, `FindObjectOfType()` in Update/FixedUpdate
- Cache component references in `Awake()` or inject them via Zenject
- Use object pooling for frequently instantiated/destroyed objects (Zenject's `MemoryPool`)
- Minimize GC allocations:
  - Avoid creating new collections in Update loops
  - Use `StringBuilder` for string concatenation
  - Reuse arrays/lists when possible
- Use `CompareTag("TagName")` instead of `gameObject.tag == "TagName"`

### Object Pooling with Zenject
```csharp
// In installer
Container.BindMemoryPool<Bullet, Bullet.Pool>()
    .WithInitialSize(10)
    .FromComponentInNewPrefab(bulletPrefab)
    .UnderTransformGroup("BulletPool");

// In class
public class BulletSpawner
{
    private readonly Bullet.Pool _bulletPool;
    
    public BulletSpawner(Bullet.Pool bulletPool)
    {
        _bulletPool = bulletPool;
    }
    
    public void Shoot()
    {
        var bullet = _bulletPool.Spawn();
        // Use bullet...
        _bulletPool.Despawn(bullet);
    }
}
```

## Error Handling & Debugging

### Null Safety
- Use nullable reference types when possible (`#nullable enable`)
- Validate injected dependencies in constructor or `Awake()`
- Use `Debug.Assert()` for development-time checks
- Prefer early returns over deep nesting:
  ```csharp
  if (player == null) return;
  // Continue with logic
  ```

### Logging Strategy
- Use Unity's `Debug.Log/Warning/Error` consistently
- Add context to log messages: `Debug.Log($"[PlayerService] Health changed: {oldHealth} -> {newHealth}")`
- Use `[Conditional("UNITY_EDITOR")]` for debug-only methods
- Consider creating a custom logger interface for easier testing

## Testing

### Unit Testing
- Write tests for business logic (POCO classes)
- Use Zenject's test framework for integration tests
- Mock dependencies using interfaces
- Keep tests fast and isolated

### Testability Checklist
- ✅ Business logic in Plain C# classes (not MonoBehaviour)
- ✅ Dependencies injected via constructor
- ✅ Public methods return values or expose events (not just side effects)
- ✅ No direct Unity API calls in business logic

## Project Organization

### Folder Structure
```
Assets/
├── Scripts/
│   ├── Core/              # Core systems, managers
│   ├── Player/            # Player-related features
│   │   ├── PlayerService.cs
│   │   ├── PlayerView.cs
│   │   └── PlayerInstaller.cs
│   ├── Enemy/             # Enemy-related features
│   ├── UI/                # UI controllers, views
│   ├── Data/              # ScriptableObjects, data models
│   └── Installers/        # Scene/Project installers
├── Prefabs/
├── Scenes/
└── Resources/
```

### File Naming
- MonoBehaviour views: `*View.cs` (e.g., `PlayerView.cs`)
- Services/Systems: `*Service.cs`, `*System.cs` (e.g., `HealthService.cs`)
- Installers: `*Installer.cs` (e.g., `PlayerInstaller.cs`)
- Interfaces: `I*.cs` (e.g., `IPlayerService.cs`)

## Anti-Patterns to Avoid

❌ **Singleton Pattern** (Use Zenject's `AsSingle()` instead)
❌ **Service Locator** (Use dependency injection)
❌ **God Classes** (Classes with too many responsibilities)
❌ **Magic Numbers** (Use named constants or configs)
❌ **Tight Coupling** (Always code to interfaces)
❌ **Update Hell** (Too much logic in Update; use event-driven design)

## Comments and Documentation

### When to Comment
- ✅ Complex algorithms or non-obvious logic
- ✅ Public API methods (XML documentation)
- ✅ Workarounds or temporary solutions (mark with `// TODO:` or `// HACK:`)
- ✅ Business rules that aren't self-evident
- ❌ Obvious code (let the code speak for itself)

### XML Documentation
```csharp
/// <summary>
/// Calculates damage after applying defense and resistances.
/// </summary>
/// <param name="baseDamage">Raw damage before modifications</param>
/// <param name="defense">Target's defense value</param>
/// <returns>Final damage to apply</returns>
public float CalculateDamage(float baseDamage, float defense)
{
    // Implementation...
}
```

### Language
- Code: English (variables, methods, classes)
- Comments: Korean or English (team preference)
- Commit messages: Korean or English (team preference)

## Best Practices Summary

1. **Inject dependencies, don't find them**
2. **Separate concerns: MonoBehaviour is just a view**
3. **Write testable code (POCO business logic)**
4. **Cache references, avoid expensive lookups**
5. **Use interfaces for abstraction**
6. **Follow SOLID principles**
7. **Keep installers organized by feature**
8. **Prefer composition over inheritance**
9. **Make performance-critical code allocation-free**
10. **Write code that's easy to understand and maintain**
