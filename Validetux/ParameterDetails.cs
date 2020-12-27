using System;

namespace Validetux
{
    public class ParameterDetails<M>
    {
        public Func<M, object> Param { get; set; }

        public string ParamName { get; set; }

        public ParameterDetails(Func<M, object> param)
        {
            Param = param;
            ParamName = nameof(Param.Target);
        }
    }
}
