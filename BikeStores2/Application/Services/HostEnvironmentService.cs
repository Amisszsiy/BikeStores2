namespace BikeStores2.Application.Services
{
    public class HostEnvironmentService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public HostEnvironmentService(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        public string GetBaseUrl()
        {
            var request = _contextAccessor.HttpContext?.Request;

            if (request != null )
            {
                var baseUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";
                return baseUrl;
            }
            else
            {
                throw new InvalidOperationException("Http Context is null");
            }
        }
    }
}
