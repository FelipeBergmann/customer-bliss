using System.Collections.Generic;
using System.Text.Json;

namespace CustomerBliss.BuildingBlocks.UseCase
{
    public class ExecutionLogList : List<ExecutionLog>
    {
        public new ExecutionLogList Add(ExecutionLog item)
        {
            base.Add(item);
            return this;
        }

        public ExecutionLogList AddInfo(string message) => this.Add(ExecutionLog.CreateInfoLog(message));
        public ExecutionLogList AddDebug(string message) => this.Add(ExecutionLog.CreateDebugLog(message));
        public ExecutionLogList AddError(string message) => this.Add(ExecutionLog.CreateErrorLog(message));
        public ExecutionLogList AddWarning(string message) => this.Add(ExecutionLog.CreateWarningLog(message));

        public override string? ToString() => JsonSerializer.Serialize(this);
    }
}