# Day 1-2: DI 기초 완전 이해 체크리스트

> **목표**: DI가 왜 필요한지 이해하고, DI 패턴으로 코드 작성할 수 있다

---

## 📅 Day 1: DI의 "왜"를 이해하기

### 1단계: 문제 상황 체감하기
- [ ] 새 Unity 씬 만들기 (`Scenes/DI_Practice_Day1.unity`)
- [ ] `Scripts/Practice/Day1` 폴더 생성
- [ ] DI 없는 코드 작성해보기 (아래 과제 참고)

#### 📝 실습 과제 1-1: DI 없는 코드의 문제점 느끼기
```csharp
// Enemy.cs - DI 없이 작성 (강결합 코드)
public class Enemy : MonoBehaviour 
{
    private HealthBar healthBar = new HealthBar();
    private DamageCalculator calculator = new DamageCalculator();
    
    void Start() 
    {
        healthBar.Initialize(100);
    }
    
    public void TakeDamage(int baseDamage) 
    {
        int finalDamage = calculator.Calculate(baseDamage);
        healthBar.Decrease(finalDamage);
    }
}
```

**당신이 할 일**:
- [ ] `HealthBar.cs` 클래스 작성
  - `Initialize(int maxHealth)` 메서드
  - `Decrease(int amount)` 메서드
  - `int CurrentHealth` 프로퍼티
- [ ] `DamageCalculator.cs` 클래스 작성
  - `Calculate(int baseDamage)` 메서드 (baseDamage * 1.5 같은 간단한 계산)
- [ ] `Enemy.cs` 작성 (위 코드 참고)
- [ ] 테스트: Enemy에게 데미지 주는 버튼 만들어보기

**체크포인트**:
- [ ] Enemy가 HealthBar를 직접 `new`로 생성하고 있나요?
- [ ] Enemy가 DamageCalculator를 직접 `new`로 생성하고 있나요?
- [ ] 이 코드의 문제점을 3가지 이상 생각해보기 (종이에 적기)

---

### 2단계: DI 패턴으로 변환하기
- [ ] `Scripts/Practice/Day1/WithDI` 폴더 생성

#### 📝 실습 과제 1-2: Interface 만들기
**당신이 할 일**:
- [ ] `IHealthBar.cs` 인터페이스 작성
  - 필요한 메서드/프로퍼티 정의
  - 힌트: HealthBar가 했던 기능들
- [ ] `IDamageCalculator.cs` 인터페이스 작성
  - 필요한 메서드 정의

**체크포인트**:
- [ ] 인터페이스 이름이 `I`로 시작하나요?
- [ ] 인터페이스에 구현 코드가 없나요? (메서드 선언만)

#### 📝 실습 과제 1-3: DI 패턴으로 Enemy 다시 작성
**당신이 할 일**:
- [ ] `EnemyWithDI.cs` 클래스 작성
  - IHealthBar, IDamageCalculator를 생성자로 받기
  - `new` 키워드 사용 금지
  - readonly 필드로 선언

**힌트**:
```csharp
public class EnemyWithDI 
{
    private readonly IHealthBar _healthBar;
    // TODO: IDamageCalculator도 추가
    
    public EnemyWithDI(???, ???) // 무엇을 받아야 할까요?
    {
        // TODO: 필드에 할당
    }
    
    public void TakeDamage(int baseDamage) 
    {
        // TODO: 기존 로직과 동일하게 작성
    }
}
```

**체크포인트**:
- [ ] `new` 키워드를 사용하지 않았나요?
- [ ] 생성자에서 의존성을 모두 받았나요?
- [ ] private 필드가 `_`로 시작하나요?
- [ ] readonly 키워드를 사용했나요?

---

### 3단계: 차이 비교하고 이해하기
- [ ] 두 코드를 나란히 놓고 비교
- [ ] 변경 사항 정리 (종이에 적기)

**생각해볼 질문**:
- [ ] EnemyWithDI는 HealthBar의 구현을 알고 있나요? (No면 성공!)
- [ ] HealthBar를 다른 것으로 교체하기 쉬워졌나요?
- [ ] 유닛 테스트 작성이 가능해졌나요? (어떻게?)

---

## 📅 Day 2: DI 패턴 연습 및 개념 정리

### 4단계: 새로운 시나리오 직접 구현
- [ ] `Scripts/Practice/Day2` 폴더 생성

#### 📝 실습 과제 2-1: Player 시스템 DI 패턴으로 구현
**요구사항**:
플레이어가 아이템을 사용할 때:
1. 인벤토리에서 아이템 차감
2. 플레이어 체력 회복
3. 사운드 재생

**당신이 할 일**:
- [ ] `IInventorySystem.cs` 인터페이스 작성
  - `bool HasItem(string itemName)` 메서드
  - `void UseItem(string itemName)` 메서드
- [ ] `IHealthSystem.cs` 인터페이스 작성
  - `void Heal(int amount)` 메서드
  - `int CurrentHealth { get; }` 프로퍼티
- [ ] `ISoundPlayer.cs` 인터페이스 작성
  - `void Play(string soundName)` 메서드
- [ ] `InventorySystem.cs` 구현 클래스 작성
- [ ] `HealthSystem.cs` 구현 클래스 작성
- [ ] `SoundPlayer.cs` 구현 클래스 작성 (Debug.Log로 대체 가능)
- [ ] `PlayerItemUser.cs` 작성
  - 생성자로 위 3개 시스템 주입받기
  - `UsePotion()` 메서드 구현

**체크포인트**:
- [ ] 모든 인터페이스가 `I` 접두사로 시작하나요?
- [ ] PlayerItemUser가 구현 클래스를 직접 알고 있지 않나요?
- [ ] 모든 의존성을 생성자로 받았나요?
- [ ] readonly 키워드를 사용했나요?

---

### 5단계: Mock 객체로 테스트 개념 이해
- [ ] `MockHealthSystem.cs` 작성

#### 📝 실습 과제 2-2: Mock 객체 만들기
**당신이 할 일**:
- [ ] IHealthSystem을 구현하는 MockHealthSystem 작성
  - Heal 호출 횟수 카운트
  - 회복량 기록
  - Debug.Log로 확인

```csharp
// 예시 구조
public class MockHealthSystem : IHealthSystem 
{
    public int HealCallCount = 0;
    public int LastHealAmount = 0;
    
    public void Heal(int amount) 
    {
        HealCallCount++;
        LastHealAmount = amount;
        Debug.Log($"Mock: Healed {amount}");
    }
    
    // TODO: CurrentHealth 프로퍼티 구현
}
```

- [ ] 테스트 씬에서 MockHealthSystem을 주입해보기
- [ ] 실제 HealthSystem으로 교체해보기
- [ ] "코드 변경 없이 동작이 바뀌는가?" 확인

**체크포인트**:
- [ ] PlayerItemUser 코드를 수정하지 않고 Mock으로 교체했나요?
- [ ] "DI의 장점 = 교체 가능성" 이해했나요?

---

### 6단계: 개념 정리
- [ ] A4 용지에 그림 그리기

**그려볼 것**:
- [ ] DI 없는 구조 vs DI 있는 구조 비교 다이어그램
- [ ] Interface의 역할
- [ ] 의존성 주입 흐름 (누가 무엇을 만들어서 누구에게 전달)

**정리 체크리스트**:
- [ ] "의존성 주입"이 무엇인지 한 문장으로 설명 가능한가?
- [ ] Constructor Injection이 무엇인지 설명 가능한가?
- [ ] Interface를 왜 사용하는지 설명 가능한가?
- [ ] DI의 장점 3가지 이상 말할 수 있나?

---

## ✅ Day 1-2 완료 기준

### 최소 달성 목표
- [ ] DI 패턴으로 최소 2개 이상의 클래스 작성 완료
- [ ] Interface 기반 설계 이해
- [ ] Constructor Injection 방식 이해
- [ ] "왜 DI가 필요한가"에 대한 명확한 답변 가능

### 이해도 자가 진단
다음 질문에 답할 수 있나요?
- [ ] "new 키워드로 직접 객체 생성하는 것의 문제점은?"
- [ ] "Interface를 사용하면 어떤 이점이 있나?"
- [ ] "Constructor Injection과 Field Injection의 차이는?"
- [ ] "Mock 객체를 왜 사용하나?"

---

## 📝 학습 노트

### 오늘 배운 핵심 개념
```
[여기에 당신만의 언어로 정리하세요]

- DI란?
- Interface의 역할
- Constructor Injection
- 느낀 점
```

### 질문 및 막힌 부분
```
[나중에 물어볼 것들]

1. 
2. 
3. 
```

### 다음 단계 (Day 3-4)
- [ ] Zenject 설치 및 기본 세팅
- [ ] MonoInstaller 이해
- [ ] Container 개념 이해
- [ ] 자동 주입 메커니즘 이해

---

**💡 팁**: 모든 체크박스를 완료할 필요는 없습니다. 핵심 개념 이해가 우선!
