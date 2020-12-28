using System;
using System.Linq.Expressions;

namespace Validetux.Models
{
    public class ParameterDetails<M>
    {
        public Func<M, object> Param { get; set; }

        public string ParamName { get; set; }

        public ParameterDetails(Expression<Func<M, object>> param)
        {
            var memberExpression = param?.Body as MemberExpression;
            var urinaryExpression = param?.Body as UnaryExpression;

            ParamName = memberExpression?.Member.Name ?? ((MemberExpression)urinaryExpression?.Operand)?.Member.Name;
            var func = param?.Compile();
            Param = func;
        }
    }
}