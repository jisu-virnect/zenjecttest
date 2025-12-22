# Zenject 학습 플랜

> Unity + Zenject(Extenject) DI 패턴 마스터하기

---

## 📚 학습 자료 구성

### Week 1: DI 기초 + Zenject 기본

#### [Day 1-2: DI 기초 완전 이해](Day1-2_DI_Basics_Checklist.md)
- **목표**: DI가 왜 필요한지 이해하고, DI 패턴으로 코드 작성 가능
- **핵심 개념**:
  - Dependency Injection이란?
  - Interface 기반 설계
  - Constructor Injection
  - Mock 객체와 테스트 가능성
- **실습**:
  - DI 없는 코드 → DI 코드로 변환
  - Player 시스템 DI 패턴으로 구현
  - Mock 객체 만들어보기

#### [Day 3-4: Zenject 기본 마스터](Day3-4_Zenject_Basics_Checklist.md)
- **목표**: Zenject가 어떻게 자동으로 의존성을 주입하는지 이해
- **핵심 개념**:
  - MonoInstaller
  - Container와 바인딩
  - [Inject] 어트리뷰트
  - AsSingle vs AsTransient
  - Constructor Injection vs Field Injection
- **실습**:
  - 첫 번째 Installer 작성
  - 간단한 점수 시스템 만들기
  - 바인딩 패턴 실험

#### [Day 5-7: 실전 투입 준비](Day5-7_Real_Project_Checklist.md)
- **목표**: 팀 프로젝트 코드를 이해하고 간단한 기능 추가 가능
- **핵심 활동**:
  - 팀 코드베이스 분석
  - 커스텀 Simple DI 이해
  - 기존 기능 복제
  - 첫 PR 올리기
- **실습**:
  - 가장 간단한 기능 완전 분해
  - 비슷한 기능 직접 만들기
  - 코드 리뷰 받기

---

## 🎯 학습 방식

### 핵심 원칙
1. **이해 우선**: 완벽히 이해하고 넘어가기보다, 60% 이해되면 실습 시작
2. **직접 작성**: 예제 복붙 금지, 모든 코드 직접 타이핑
3. **디버깅 활용**: 브레이크포인트로 실행 흐름 눈으로 확인
4. **빠른 질문**: 30분 막히면 바로 질문하기

### 체크리스트 활용법
- [ ] VS Code에서 마크다운 미리보기로 열기
- [ ] 각 과제를 순서대로 진행
- [ ] 체크박스를 체크하며 진행 상황 확인
- [ ] 막히는 부분은 "질문 및 막힌 부분"에 메모
- [ ] 학습 노트 섹션에 자신만의 언어로 정리

---

## 📅 전체 타임라인

### Week 1
- **Day 1-2**: DI 기초 이해
- **Day 3-4**: Zenject 기본 마스터
- **Day 5-7**: 실전 코드베이스 분석

### Week 2
- 간단한 버그 픽스
- 작은 기능 추가
- 코드 리뷰 적극 참여

### Week 3
- 중급 기능 개발
- 아키텍처 개선 제안

### Month 2-3
- 복잡한 기능 설계 및 구현
- 다른 팀원 멘토링

---

## 📂 폴더 구조

```
zenjecttest/
├── README.md (이 파일)
├── Day1-2_DI_Basics_Checklist.md
├── Day3-4_Zenject_Basics_Checklist.md
└── Day5-7_Real_Project_Checklist.md

Assets/Scripts/Practice/ (Unity 프로젝트 내)
├── Day1/
│   ├── Enemy.cs
│   ├── HealthBar.cs
│   ├── WithDI/
│   │   ├── IHealthBar.cs
│   │   └── EnemyWithDI.cs
│   └── ...
├── Day2/
│   ├── IInventorySystem.cs
│   ├── PlayerItemUser.cs
│   └── ...
├── Day3/
│   ├── MyFirstInstaller.cs
│   ├── IGreeter.cs
│   └── ...
└── Day4/
    ├── ScoreSystem.cs
    ├── ScoreInstaller.cs
    └── ...
```

---

## 🔧 준비물

### 필수
- [ ] Unity 2021.3 이상
- [ ] Extenject (Zenject) 패키지 설치
- [ ] Visual Studio 또는 Rider
- [ ] Git

### 추천
- [ ] Unity Debugger 설정
- [ ] Markdown 편집기 (VS Code)

---

## 💡 학습 팁

### 이해 중심 학습자를 위한 조언
1. **작은 범위를 깊게**: 전체를 대충 보지 말고, 한 가지 개념을 완전히 이해
2. **그림으로 정리**: A4 용지에 손으로 구조도 그리기
3. **Why-Driven**: "왜?"를 계속 물어보며 코드 읽기
4. **실험하기**: 코드 바꿔보면서 어떻게 동작하는지 확인

### 막힐 때
1. 디버거로 코드 흐름 추적
2. 비슷한 예제 코드 찾아보기
3. 30분 고민 후 질문하기
4. 팀원에게 페어 프로그래밍 요청

### 성장하는 법
1. 다른 사람 코드 리뷰 보기
2. "왜?"를 계속 질문하기
3. 작은 성공 경험 쌓기
4. 실수해도 괜찮다는 마인드

---

## 📖 참고 자료

### 공식 문서
- [Zenject GitHub](https://github.com/modesttree/Zenject)
- [Extenject (OpenUPM)](https://openupm.com/packages/com.svermeulen.extenject/)

### 추천 읽을거리
- Dependency Injection 기초 개념
- SOLID 원칙
- Unity Test Framework

---

## ✅ 진행 상황

### Week 1
- [ ] Day 1-2 완료
- [ ] Day 3-4 완료
- [ ] Day 5-7 완료

### 달성 마일스톤
- [ ] DI 패턴 이해
- [ ] Zenject 기본 사용법 마스터
- [ ] 팀 코드베이스 이해
- [ ] 첫 PR 머지
- [ ] 버그 픽스 완료
- [ ] 새 기능 추가 완료

---

## 🎉 목표

**"2-3주 후 실무 투입 가능한 수준 달성"**

- ✅ DI 패턴으로 코드 작성 가능
- ✅ Zenject Installer 작성 가능
- ✅ 팀 코드베이스 이해
- ✅ 간단한 기능 추가 가능
- ✅ 코드 리뷰 참여 가능

---

**시작 날짜**: 2025년 12월 22일  
**목표 완료일**: 2026년 1월 중순

화이팅! 🚀
