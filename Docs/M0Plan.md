# RounRounGrowth — M0 阶段计划（导航系统基础）

> 本文为 M0 阶段原计划文档（保留历史结构）  
> 最新规范参见 [DocumentationGuidelines](/Docs/DocumentationGuidelines.md)

---

## 阶段目标

- **BuildingNavigator / Manager / NavigationTable**
- **Map 盖层与房间跳转**
- **同层滑动**（PageSwipeDetector + SwipeToNavigate）
- **顶部导航条**（TopNavBar）
- **楼层电梯**（Elevator Selector）

---

## 阶段状态

- [x] M0-1 枚举定义与导航表
- [x] M0-2 面板管理器
- [x] M0-3 实现房间导航系统
- [x] M0-4 Map 手势与房间选择
- [x] M0-5 同层左右滑
- [x] M0-6 顶部导航条
- [x] M0-7 楼层电梯

---

## M0-6 顶部导航条（TopNavBar）

### 任务目标
- [x] 动态生成当前楼层的房间标题  
- [x] 当前房间标题高亮  
- [x] 点击标题切换房间  
- [ ] 长按导航条打开 Map（推迟到 M3）

###  主要文件
- TopNavBar.cs  
- TopNavButton.cs  
- BuildingNavigator.cs  
- BuildingNavigationTable.cs  

---

## M0-7 楼层电梯（Elevator Selector）

### 任务目标

- [x] M0-7-1 建立 ElevatorOverlay 基础框架  
    - 创建电梯面板 UI（含楼层按钮容器）  
    - 挂载空脚本，确保能在场景中显示/隐藏  

- [x] M0-7-2 实现显示与隐藏逻辑  
    - 点击电梯图标可展开或收起 ElevatorOverlay  
    - 点击面板外区域关闭电梯面板  
    - 面板初始为隐藏状态  

- [x] M0-7-3 实现高亮当前楼层按钮  

- [x] M0-7-4 实现点击楼层切换逻辑  
    - 点击其他楼层调用 `BuildingNavigator.Show()` 切换到该层默认房间  
    - 点击当前楼层无反应  

- [x] M0-7-5 加入关闭条件（外部与 Map 交互）  
    - 打开地图时自动关闭电梯面板  

- [x] M0-7-6 楼层电梯结构优化（Refactor）  
    - 将 ElevatorOverlay 中的按钮点击与高亮逻辑迁移至新组件 ElevatorFloorButton  
    - ElevatorOverlay 仅负责整体面板的开关与地图联动  
    - 每个 ElevatorFloorButton 自行处理点击事件与高亮更新  
    - 无新增动画与音效，专注结构解耦与可维护性  

### 主要文件
- ElevatorOverlay.cs  
- ElevatorFloorButton.cs  
- ElevatorButton.cs  
- BuildingNavigator.cs  
- BuildingNavigationTable.cs  

---

## 阶段文件总览（M0 核心）

| 分类 | 文件名 |
|------|--------|
| 核心导航 | BuildingNavigator.cs / BuildingManager.cs / BuildingNavigationTable.cs |
| 地图交互 | MapGestureSimulator.cs / PageSwipeDetector.cs / SwipeToNavigate.cs |
| 导航条 | TopNavBar.cs / TopNavButton.cs |
| 电梯系统 | ElevatorOverlay.cs / ElevatorFloorButton.cs / ElevatorButton.cs |

---

## 备注

- 本阶段以「功能闭环」为核心，不追求动画或视觉过渡  
- M0 全阶段任务已完成，进入 M1 功能模块实现阶段
