export class TaskUtils{
  static taskStates = ["todo", "doing", "done", "abandoned", "hold", "todo"];
  static unknownState = "unknown";
  className = "unknown";
  static getClassName(task): string {
    if (task.state != null && task.state >= 0 && task.state < this.taskStates.length) {
      return this.taskStates[task.state]
    } else {
      return this.unknownState;
    }
  }
}