namespace VectorApi.Infrastructure.Middlewares
{
    public class VerifyVector
    {
        private readonly RequestDelegate _next;

        public VerifyVector(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

        }
    }
}
