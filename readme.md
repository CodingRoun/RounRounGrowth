# 🏢 RounRoun Growth  
> 「圆肚成长计划」—— 一款融合时间管理、情绪追踪与奖励机制的互动应用  

![Unity](https://img.shields.io/badge/Engine-Unity%206.0%20(6000.0.49f1)-blue)
![.NET](https://img.shields.io/badge/.NET-Standard%202.1-512BD4)
![C#](https://img.shields.io/badge/Language-C%23-178600)
![Progress](https://img.shields.io/badge/Phase-M1%20功能模块实现-brightgreen)
![License](https://img.shields.io/badge/License-MIT-green)

---

## 🌱 项目简介

**RounRoun Growth（圆肚成长计划）** 是一个融合 **番茄钟 × 情绪追踪 × 游戏化奖励系统** 的成长陪伴应用。  
用户在虚构的「圆肚互娱公司」中完成任务、记录心情、获取奖励，并在轻松荒诞的叙事氛围中进行自我成长。  

项目目标是构建一个：
- 🏗️ 模块化、事件驱动的 Unity 架构；
- 🕹️ 拥有情感反馈与陪伴感的 UI；
- 💾 支持数据持久化与每日成长反馈的系统。

---

## 🧭 当前阶段：M1 功能模块实现
> 🚀 **目标：为各功能房间建立可运行逻辑。**

---

## 🧭 已完成：M0 导航系统基础

> ✅ **目标：完成房间与楼层的导航闭环。**

### 已完成功能
- [x] 枚举定义与导航表（`BuildingTypes` / `BuildingNavigationTable`）  
- [x] 面板管理器（`BuildingManager`）  
- [x] 房间导航系统（`BuildingNavigator`）  
- [x] Map 手势与房间选择（`MapGestureSimulator` + `MapRoomButton`）  
- [x] 同层左右滑（`PageSwipeDetector` + `SwipeToNavigate`）  
- [x] 顶部导航条点击跳转（`TopNavBar` + `TopNavButton`）  
- [x] 楼层电梯面板（`ElevatorOverlay` + `ElevatorButton` + `ElevatorFloorButton`）  

---

## 🧩 核心架构

```plaintext
RounRounGrowth/
│
├── Core/
│   ├── BuildingTypes.cs              # 枚举与位置结构定义
│   └── BuildingNavigationTable.cs    # 楼层与房间映射表
│
├── Building/
│   ├── BuildingManager.cs            # 面板实例管理
│   └── BuildingNavigator.cs          # 楼层与房间导航控制
│
└── UI/
    ├── PageSwipeDetector.cs          # 滑动检测（左右换页）
    ├── SwipeToNavigate.cs            # 滑动换房间逻辑
    ├── MapRoomButton.cs              # Map房间按钮（点击跳转）
    ├── MapGestureSimulator.cs        # Ctrl+M 打开Map模拟
    ├── MapOverlay.cs                 # 打开Map时隐藏浮动UI
    ├── TopNavBar.cs                  # 顶部导航条生成与高亮
    ├── TopNavButton.cs               # 顶部按钮实例与选中状态
    ├── ElevatorButton.cs             # 打开/关闭电梯面板按钮
    ├── ElevatorOverlay.cs            # 楼层切换菜单与事件分发
    └── ElevatorFloorButton.cs        # 单个楼层按钮（点击跳转 + 高亮状态）
```

---

## 🧠 架构理念

- **单一入口（Single Entry）**：所有房间导航均通过 `BuildingNavigator.Show()` 控制；
- **事件驱动（Event Driven）**：房间变化由 `OnRoomChanged` 广播至 UI 层；
- **功能解耦（Decoupled Design）**：Map、滑动、按钮、导航条独立实现；
- **情感化体验（Emotional UX）**：以“圆肚宇宙”角色陪伴用户成长。

---

## 🧪 开发环境

| 项目 | 版本 |
|------|------|
| Unity | 6.0 (6000.0.49f1) |
| .NET  | .NET Standard 2.1 |
| IDE | Visual Studio / Rider |
| 平台 | Windows / macOS / Android / iOS |

---

## 🔖 Commit 规范

每个番茄任务对应一次提交，模板位于 `.gitmessage.txt`。  
示例：

```bash
feat: [M0-5] 实现 SwipeToNavigate 页面切换（番茄#6）

Code:
- 将 PageSwipeDetector 的 OnSwipe 事件与导航器绑定
- 实现左右滑动页面切换
- 支持边界 return
```

---

## 🦯 未来阶段计划

| 阶段 | 内容 | 状态 |
|------|------|------|
| M0 | 导航系统基础 | ✅ 已完成 |
| M1 | 功能模块实现（大厅、心情、计划、抽卡、专注） | 🚀 进行中 |
| M2 | 数据与存档系统 | 🔜 |
| M3 | 交互与视觉优化 | 🔜 |
| M4 | 延后内容（业绩系统、卫生间、老板办公室） | 🔒 |
| M5 | 优化与版本发布 | 🔜 |

---

## 🧑‍💻 作者
**CodingRoun / 圆肚互娱员工**  
> “有点笨，但在变圆的路上。”  

📘 [项目文档](./Docs/) ｜ 💬 [交流与反馈](https://github.com/CodingRoun/RounRounGrowth/issues)

---

## 📄 License
本项目基于 MIT License 开源。  
你可以自由修改、分发与学习，但请保留署名与引用。

---

> “RounRoun 成长的每一天，  
>  都是你和时间的温柔对话。”

---

