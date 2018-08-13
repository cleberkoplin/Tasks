using System.ComponentModel;

namespace Tasks.Data.ValueObjects
{
    public enum TaskStatus
    {
        [Description("Pendente")]
        Pendente = 0,
        [Description("Concluido")]
        Concluido = 1
    }
}
