namespace Api.Extensoes
{
    public static class TratamentoDeExcecaoGlobalMiddlewareExtensao
    {
        public static IServiceCollection AdicionarTratamentoDeExcecaoGlobalMiddleware(this IServiceCollection services)
        {
            return services.AddTransient<TratamentoDeExcecaoGlobalMiddleware>();
        }

        public static void UseTratamentoDeExcecaoGlobalMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<TratamentoDeExcecaoGlobalMiddleware>();
        }
    }
}
