# GitHub Copilot Instructions

## Project Overview
This is a Unity project using Zenject (Extenject) for dependency injection.

## Code Style Guidelines

### C# and Unity
- Follow Unity C# naming conventions
- Use PascalCase for public methods and properties
- Use camelCase for private fields with underscore prefix (e.g., `_myField`)
- Add `[SerializeField]` attribute for private fields that need to be visible in Inspector
- Use `#region` blocks to organize code sections when appropriate

### Zenject/Extenject Patterns
- Use constructor injection as the primary injection method
- Create installers inheriting from `MonoInstaller` or `ScriptableObjectInstaller`
- Bind dependencies in `InstallBindings()` method
- Use `FromInstance()`, `FromComponentInHierarchy()`, `AsSingle()`, `AsTransient()` appropriately
- Avoid using `Container.Resolve()` directly; prefer constructor injection

### Unity Best Practices
- Avoid using `FindObjectOfType` or `GameObject.Find` when possible
- Use dependency injection instead of singleton patterns
- Keep MonoBehaviour classes lightweight
- Separate game logic from Unity-specific code
- Use `[Inject]` attribute for field/property injection only when constructor injection is not possible

## Architecture
- Follow SOLID principles
- Keep business logic separate from presentation layer
- Use interfaces for abstraction
- Organize scripts by feature or domain

## Comments and Documentation
- Add XML documentation comments for public APIs
- Use clear, descriptive variable and method names
- Comment complex logic or non-obvious implementations
- Korean comments are acceptable for team communication
