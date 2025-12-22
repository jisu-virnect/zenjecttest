# Day 3-4: Zenject 기본 완전 이해 체크리스트

> **목표**: Zenject가 어떻게 자동으로 의존성을 주입하는지 이해하고, Installer를 작성할 수 있다

---

## 📅 Day 3: Zenject 설치 및 핵심 개념 이해

### 1단계: Zenject 설치 및 세팅
- [ ] Package Manager에서 Extenject(Zenject) 설치 확인
- [ ] 새 씬 생성 (`Scenes/Zenject_Practice_Day3.unity`)
- [ ] `Scripts/Practice/Day3` 폴더 생성

**체크포인트**:
- [ ] Zenject이 설치되어 있나요?
- [ ] using Zenject; 사용 가능한가요?

---

### 2단계: 첫 번째 Installer 만들기
- [ ] Scene에 빈 GameObject 생성하고 이름을 "SceneContext"로 변경
- [ ] SceneContext 컴포넌트 추가

#### 📝 실습 과제 3-1: 가장 간단한 Installer 작성
**당신이 할 일**:
- [ ] `MyFirstInstaller.cs` 작성 (MonoInstaller 상속)
- [ ] InstallBindings() 메서드 오버라이드
- [ ] 간단한 바인딩 하나 추가

**힌트**:
```csharp
using Zenject;

public class MyFirstInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // TODO: 여기서 바인딩을 추가합니다
        // Container.Bind<???>().To<???>().AsSingle();
    }
}
```

**바인딩할 클래스 (먼저 만들기)**:
- [ ] `IGreeter.cs` 인터페이스 작성
  - `string Greet()` 메서드
- [ ] `SimpleGreeter.cs` 구현 클래스 작성
  - IGreeter 구현
  - Greet() 메서드가 "Hello from Zenject!" 반환

**체크포인트**:
- [ ] MonoInstaller를 상속했나요?
- [ ] InstallBindings() 메서드를 오버라이드했나요?
- [ ] SceneContext의 Installers 목록에 MyFirstInstaller를 추가했나요?

---

### 3단계: 주입 받아보기
#### 📝 실습 과제 3-2: Field Injection 테스트
**당신이 할 일**:
- [ ] `GreeterTester.cs` MonoBehaviour 작성
- [ ] [Inject] 어트리뷰트로 IGreeter 주입받기
- [ ] Start()에서 Greet() 호출해서 로그 출력

**힌트**:
```csharp
using UnityEngine;
using Zenject;

public class GreeterTester : MonoBehaviour
{
    [Inject] private IGreeter _greeter; // TODO: 이렇게 주입받습니다
    
    void Start()
    {
        // TODO: _greeter.Greet() 호출해서 Debug.Log
    }
}
```

- [ ] 씬에 빈 GameObject 추가하고 GreeterTester 컴포넌트 추가
- [ ] 게임 실행 후 로그 확인

**체크포인트**:
- [ ] "Hello from Zenject!" 로그가 나타났나요?
- [ ] _greeter가 null이 아닌가요?
- [ ] Zenject가 자동으로 주입해줬다는 것을 확인했나요?

---

### 4단계: Container의 역할 이해하기
- [ ] 디버거로 실행 흐름 추적하기

#### 📝 실습 과제 3-3: 디버깅으로 이해하기
**당신이 할 일**:
- [ ] MyFirstInstaller.InstallBindings()에 브레이크포인트 설정
- [ ] GreeterTester.Start()에 브레이크포인트 설정
- [ ] Unity Editor를 Attach해서 디버깅 시작

**확인할 것**:
- [ ] InstallBindings()가 언제 호출되나요? (게임 시작 시)
- [ ] Start()가 호출될 때 _greeter에 이미 값이 들어가 있나요?
- [ ] _greeter의 타입은? (SimpleGreeter)

**생각해볼 질문**:
- [ ] Container는 언제 객체를 생성하나요?
- [ ] Container는 어떻게 _greeter에 값을 넣어주나요?
- [ ] 종이에 흐름도 그려보기

---

### 5단계: Constructor Injection 시도
#### 📝 실습 과제 3-4: Plain C# 클래스에서 주입받기
**당신이 할 일**:
- [ ] `IMessagePrinter.cs` 인터페이스 작성
  - `void Print(string message)` 메서드
- [ ] `ConsoleMessagePrinter.cs` 구현 클래스 작성
  - Debug.Log로 출력
- [ ] `GreeterService.cs` 클래스 작성 (MonoBehaviour 아님!)
  - Constructor로 IGreeter와 IMessagePrinter 주입받기
  - `void SayHello()` 메서드 구현

**힌트**:
```csharp
public class GreeterService 
{
    private readonly IGreeter _greeter;
    private readonly IMessagePrinter _printer;
    
    // TODO: Constructor 작성
    public GreeterService(???, ???)
    {
        // TODO: 필드에 할당
    }
    
    public void SayHello()
    {
        string greeting = _greeter.Greet();
        _printer.Print(greeting);
    }
}
```

- [ ] Installer에서 3개 모두 바인딩하기
  - IGreeter → SimpleGreeter
  - IMessagePrinter → ConsoleMessagePrinter
  - GreeterService (인터페이스 없이 바로 바인딩)
- [ ] GreeterTester에서 GreeterService 주입받아서 SayHello() 호출

**체크포인트**:
- [ ] GreeterService가 MonoBehaviour를 상속하지 않나요?
- [ ] Constructor Injection이 동작하나요?
- [ ] 여러 의존성을 동시에 주입받을 수 있나요?

---

## 📅 Day 4: Zenject 바인딩 패턴 마스터

### 6단계: AsSingle vs AsTransient 이해
#### 📝 실습 과제 4-1: 인스턴스 생성 방식 실험
**당신이 할 일**:
- [ ] `Scripts/Practice/Day4` 폴더 생성
- [ ] `CounterService.cs` 작성

```csharp
public class CounterService 
{
    private static int _instanceCount = 0;
    public int InstanceNumber { get; }
    
    public CounterService()
    {
        _instanceCount++;
        InstanceNumber = _instanceCount;
        Debug.Log($"CounterService 인스턴스 #{InstanceNumber} 생성됨");
    }
}
```

**실험 1: AsSingle**
- [ ] Installer에서 `Container.Bind<CounterService>().AsSingle();` 바인딩
- [ ] 3개의 다른 클래스에서 CounterService 주입받기
- [ ] 각각 InstanceNumber 로그 출력
- [ ] 결과 예상: 모두 같은 번호 (예: #1, #1, #1)

**실험 2: AsTransient**
- [ ] `.AsSingle()`을 `.AsTransient()`로 변경
- [ ] 다시 실행
- [ ] 결과 예상: 다른 번호 (예: #1, #2, #3)

**체크포인트**:
- [ ] AsSingle과 AsTransient의 차이를 명확히 이해했나요?
- [ ] 언제 AsSingle을 써야 하나요? (GameManager, ScoreManager 등)
- [ ] 언제 AsTransient를 써야 하나요? (Enemy, Bullet 등)

---

### 7단계: 다양한 바인딩 방법 실습
#### 📝 실습 과제 4-2: FromInstance, FromNew 등 이해하기

**당신이 할 일**:
- [ ] `GameConfig.cs` ScriptableObject 작성
  - `int MaxEnemies` 필드
  - `float GameSpeed` 필드
- [ ] Inspector에서 GameConfig 에셋 생성

**바인딩 방법 테스트**:
```csharp
[SerializeField] private GameConfig _config; // Inspector에서 할당

public override void InstallBindings()
{
    // TODO: 기존 인스턴스 바인딩
    Container.Bind<GameConfig>().FromInstance(_config).AsSingle();
    
    // TODO: 다른 바인딩 방법들도 시도
}
```

- [ ] `FromInstance()` 테스트 (기존 객체 사용)
- [ ] `FromNew()` 테스트 (매번 새로 생성)
- [ ] 다른 클래스에서 GameConfig 주입받아서 값 사용

**체크포인트**:
- [ ] FromInstance는 언제 사용하나요?
- [ ] ScriptableObject를 어떻게 주입하나요?

---

### 8단계: 실전 예제 통합
#### 📝 실습 과제 4-3: 간단한 점수 시스템 만들기
**요구사항**:
- 버튼 클릭 → 점수 증가 → UI 업데이트

**당신이 할 일**:
- [ ] `IScoreSystem.cs` 인터페이스
  - `int CurrentScore { get; }`
  - `void AddScore(int points)`
  - `event Action<int> OnScoreChanged`
- [ ] `ScoreSystem.cs` 구현
- [ ] `ScoreUI.cs` MonoBehaviour
  - TextMeshPro로 점수 표시
  - OnScoreChanged 이벤트 구독
- [ ] `ScoreButton.cs` MonoBehaviour
  - 버튼 클릭 시 AddScore(10) 호출
- [ ] `ScoreInstaller.cs` 작성
  - IScoreSystem 바인딩

**체크포인트**:
- [ ] ScoreSystem은 AsSingle로 바인딩했나요?
- [ ] ScoreUI와 ScoreButton이 같은 ScoreSystem 인스턴스를 공유하나요?
- [ ] 버튼 클릭 시 UI가 업데이트되나요?

---

### 9단계: 개념 정리 및 문서화
- [ ] A4 용지에 Zenject 동작 원리 그리기

**그려볼 것**:
```
[게임 시작]
    ↓
[SceneContext 초기화]
    ↓
[Installer.InstallBindings()]
    ↓
[Container에 바인딩 등록]
  IGreeter → SimpleGreeter
  IScoreSystem → ScoreSystem
    ↓
[MonoBehaviour 주입]
    ↓
[Plain C# 클래스 생성 시 자동 주입]
```

**정리 체크리스트**:
- [ ] Installer의 역할을 설명할 수 있나요?
- [ ] Container가 무엇인지 설명할 수 있나요?
- [ ] AsSingle vs AsTransient 차이를 설명할 수 있나요?
- [ ] Constructor Injection vs Field Injection 차이를 설명할 수 있나요?

---

## ✅ Day 3-4 완료 기준

### 최소 달성 목표
- [ ] MonoInstaller 작성 가능
- [ ] Container.Bind() 문법 이해
- [ ] [Inject] 어트리뷰트 사용법 이해
- [ ] AsSingle, AsTransient 차이 이해
- [ ] 간단한 시스템을 Zenject로 구현 가능

### 이해도 자가 진단
다음 질문에 답할 수 있나요?
- [ ] "Zenject가 어떻게 자동으로 주입하나요?"
- [ ] "Installer는 언제 실행되나요?"
- [ ] "Container는 무엇을 저장하나요?"
- [ ] "왜 Constructor Injection을 선호하나요?"

---

## 📝 학습 노트

### 오늘 배운 핵심 개념
```
[여기에 당신만의 언어로 정리하세요]

- Installer의 역할:
- Container의 역할:
- 바인딩이란:
- 주입 메커니즘:
```

### 질문 및 막힌 부분
```
[나중에 물어볼 것들]

1. 
2. 
3. 
```

### 다음 단계 (Day 5-7)
- [ ] 팀 코드베이스 분석
- [ ] 커스텀 Simple DI 이해
- [ ] 실전 기능 복제
- [ ] 작은 태스크 시작

---

**💡 팁**: 디버거를 적극 활용하세요! 코드 흐름을 눈으로 보는 게 이해의 지름길입니다.
