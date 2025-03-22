using Microsoft.AspNetCore.Diagnostics;

namespace Api.Extensoes
{
    public static class DetalhesDoProblemaExtensao
    {
        public static void UseDetalhesDoProblemaExcecao(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async contexto =>
                {
                    var recursoTratamentoExcecao = contexto.Features.Get<IExceptionHandlerFeature>();

                    if(recursoTratamentoExcecao != null)
                    {
                        var excecao = recursoTratamentoExcecao.Error;

                        var detalhesDoProblema = new ProblemDetails
                        {
                            Instance = contexto.Request.HttpContext.Request.Path
                        };

                        if(excecao is BadHttpRequestException badHttpRequestException)
                        {
                            detalhesDoProblema.Title = "A solicitação é inválida";
                            detalhesDoProblema.Status = StatusCodes.Status400BadRequest;
                            detalhesDoProblema.Detail = badHttpRequestException.Message;
                        }
                        else
                        {
                            var logger = loggerFactory.CreateLogger("Tratamento de exceção global.");
                            logger.LogError($"Erro inesperado: {recursoTratamentoExcecao.Error}");

                            detalhesDoProblema.Title = excecao.Message;
                            detalhesDoProblema.Status = StatusCodes.Status500InternalServerError;
                            detalhesDoProblema.Detail = excecao.StackTrace;
                        }

                        contexto.Response.StatusCode = detalhesDoProblema.Status.Value;
                        contexto.Response.ContentType = "application/problem+json";

                        var json = JsonConvert.SerializeObject(detalhesDoProblema);
                        await contexto.Response.WriteAsync(json);
                    }
                });
            });
        }
    }
}
