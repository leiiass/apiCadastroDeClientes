namespace Api.Middlewares
{
    public class TratamentoDeExcecaoGlobalMiddleware : IMiddleware
    {
        private readonly ILogger<TratamentoDeExcecaoGlobalMiddleware> _logger;

        public TratamentoDeExcecaoGlobalMiddleware(ILogger<TratamentoDeExcecaoGlobalMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro inesperado: {ex}");
                await TratarExcecaoAsync(context, ex);
            }
        }

        private static Task TratarExcecaoAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var json = new
            {
                context.Response.StatusCode,
                Message = "Ocorreu um erro ao processar sua solicitação",
                Detailed = exception
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
        }
    }
}
