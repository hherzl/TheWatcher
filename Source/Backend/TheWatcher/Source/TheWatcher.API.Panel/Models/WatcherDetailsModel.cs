namespace TheWatcher.API.Panel.Models
{
    public record WatcherDetailsModel
    {
        public short? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ClassName { get; set; }
        public Guid? ClassGuid { get; set; }
        public string AssemblyQualifiedName { get; set; }

        public List<WatcherParameterDetailsModel> Parameters { get; set; }
    }

    public record WatcherParameterDetailsModel
    {
        public WatcherParameterDetailsModel()
        {
        }

        public WatcherParameterDetailsModel(short? id, bool? isDefault, string? parameter, string? value, string? description)
        {
            Id = id;
            IsDefault = isDefault;
            Parameter = parameter;
            Value = value;
            Description = description;
        }

        public short? Id { get; set; }
        public bool? IsDefault { get; set; }
        public string Parameter { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
