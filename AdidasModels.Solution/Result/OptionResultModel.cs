namespace AdidasModels.Solution
{
    /// <summary>
    /// Option to return to the model
    /// </summary>
    public class OptionResultModel<T>
    {
        /// <summary>
        /// name
        /// </summary>
        public string Label {get; set;}

        /// <summary>
        /// value
        /// </summary>
        public object Value {get; set;}
    }

    /// <summary>
    /// Option to return to the model
    /// </summary>
    public class OptionResultModel: OptionResultModel<object>
    {
    }
}