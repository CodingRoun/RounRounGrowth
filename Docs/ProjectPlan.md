# RounRounGrowth — 项目阶段计划面板

> 本文为项目原计划文档（保留历史结构）  
> 最新规范参见 [DocumentationGuidelines](/Docs/DocumentationGuidelines.md)

---

## 阶段总览

| 阶段 | 内容 | 状态 |
|------|------|------|
| M0 | 导航系统基础 | ✅ 已完成 |
| M1 | 功能模块实现 | 🚀 进行中 |
| M2 | 数据与存档系统 | 🔜 |
| M3 | 交互与视觉优化 | 🔜 |
| M4 | 延后内容（业绩系统、卫生间、老板办公室） | 🔒 |
| M5 | 优化与版本发布 | 🔜 |

---

## M0 · 导航系统基础（已完成）

### 目标
完成房间与楼层的导航闭环。

### 内容
- `BuildingNavigator / Manager / NavigationTable` 
- Map 盖层与房间跳转 
- 同层滑动（`PageSwipeDetector + SwipeToNavigate`） 
- 顶部导航条（`TopNavBar`）
- 楼层电梯（`Elevator Selector`）

### 完成标志
- 可通过 Map、滑动、电梯自由切换
- 页面状态一致，无输入穿透

---

## M1 · 功能模块实现（当前阶段）

### 目标
为各功能房间建立可运行逻辑。

### 内容
- `LobbyRoom`（大厅）
- `MoodRoom`（心情房间）
- `PlanRoom`（计划房间）
- `ScheduleRoom`（日程房间）
- `GachaRoom`（抽卡房间）
- `FocusRoom`（专注房间）
- `CoinSystem`（货币系统）

### 完成标志

- 各功能可独立运行
- `BuildingNavigator` 能正常调度所有模块

---

## M2 · 数据与存档系统

### 目标
实现持久化存储与状态恢复。

### 内容
- `SaveLoadService`（JSON / Binary）
- `PlayerData / CurrencySystem`
- `UnlockProgress / DailyStats`

### 完成标志
- 重启后状态保持
- 数据结构稳定

---

## M3 · 交互与视觉优化

### 目标
提升操作反馈与界面体验。

### 内容
- 动画系统（过渡、回弹、缩放）
- 点击 / 滑动反馈
- UI 风格统一（颜色、字体、布局）

### 完成标志
- 操作流畅且有反馈
- 视觉统一、无交互延迟  

---

## M4 · 延后阶段
（业绩系统 / 卫生间 / 老板办公室）

### 说明
延后实现，待核心功能稳定后重新规划。

---

## M5 · 优化与版本发布

### 目标

确保性能、稳定性与多平台兼容。

### 内容

- 场景加载优化
- 异常处理 / 日志系统
- 平台适配（Android / iOS）

### 完成标志

- 稳定版本可发布
