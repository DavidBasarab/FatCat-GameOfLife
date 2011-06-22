using System.Reflection;

namespace FatCat.GameOfLife.Logic
{
    public static class Extensions
    {
        public static string GetPropertyName(this MethodBase methodBase)
        {
            return methodBase.Name.Substring(4);
        }
    }
}