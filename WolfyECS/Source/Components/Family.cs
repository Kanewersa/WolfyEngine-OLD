namespace WolfyECS
{
    public static class Family
    {
        /// <summary>
        /// Returns the family identifier of component type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int GetComponentFamily<T>()
        {
            return EntityComponent<T>.Family();
        }
    }
}