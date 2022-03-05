using System.Collections.Generic;

namespace AdidasModels.Solution
{
    /// <summary>
    /// Tree result model
    /// </summary>
    public class TreeResultModel<T>
    {
        public string Id {get; set;}

        public string Title {get; set;}

        public bool Spread {get; set;}

        public List<T> Children {get; set;}
    }

    /// <summary>
    /// Tree result model
    /// </summary>
    public class TreeResultModel: OptionResultModel<object>
    {
    }
}