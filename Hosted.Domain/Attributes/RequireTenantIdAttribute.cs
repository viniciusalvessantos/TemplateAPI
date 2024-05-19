namespace Hosted.Domain.Attributes {

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class RequireTenantIdAttribute : Attribute {
        public bool IsRequired { get; }

        public RequireTenantIdAttribute(bool isRequired = true) {
            IsRequired = isRequired;
        }
    }
}
