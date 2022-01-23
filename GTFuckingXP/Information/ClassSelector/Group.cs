namespace GTFuckingXP.Information.ClassSelector
{
    /// <summary>
    /// An information class containing group name and an id for putting different classes into different headers of the class selector.
    /// </summary>
    public class Group
    {
        public Group(int persistentId, string name)
        {
            PersistentId = persistentId;
            Name = name;
        }

        /// <summary>
        /// Gets or sets the single existing key for this <see cref="Group"/>.
        /// </summary>
        public int PersistentId { get; set; }

        /// <summary>
        /// Gets or sets the name this group should run under.
        /// </summary>
        public string Name { get; set; }
    }
}
