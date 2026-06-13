namespace BackOffice.Controllers.Attribute
{
    public static class HttpContextExtensions
    {
        public static Guid GetClientId(this HttpContext context)
        {
            return context.Items.TryGetValue("ClientId", out var id) ? (Guid)id! : Guid.Empty;
        }

        public static Guid GetStoreId(this HttpContext context)
        {
            return context.Items.TryGetValue("StoreId", out var id) ? (Guid)id! : Guid.Empty;
        }
    }
}
