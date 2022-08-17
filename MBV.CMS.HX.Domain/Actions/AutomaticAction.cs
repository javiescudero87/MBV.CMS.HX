using MBV.CMS.HX.Domain.Elements;


namespace MBV.CMS.HX.Domain.Actions
{
    public abstract class AutomaticAction<T, D, E> : Action<T>, IAutomaticAction where T : IElement
    {
        protected AutomaticAction(T? subject) : base(subject)
        {
        }

        public abstract AutomaticActionExecuteResult<D, E> InternalExecute(); 
        public void Execute()
        {
            var result = InternalExecute();
            Data = result.Data;
            Evidence = result.Evidence;
            foreach (var c in result.Changes)
                Subject.UpdateState(c);
            Status = ActionStatusValues.Done;
        }
    }
}
