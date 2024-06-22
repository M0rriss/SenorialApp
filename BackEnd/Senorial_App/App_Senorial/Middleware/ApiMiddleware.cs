using AutoMapper;
using CommonModels.Common;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RequestResponseModels.Response.Schema_Generico.GenericResponse;

namespace App_Senorial.Middleware
{
    public class ApiMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IHelperHttpContext _helperHttpContext;
        private readonly IMapper _mapper;
        public ApiMiddleware(RequestDelegate next, IMapper mapper)
        {
            this.next = next;
            _helperHttpContext = new HelperHttpContext();
            _mapper = mapper;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering();
                await next(context);
            }
            catch (SqlException ex)
            {
                CustomException customEx = new CustomException("001", "Error en base de datos");
                await HandleExceptionAsync(context, customEx);
            }
            catch (DbUpdateException ex)
            {
                CustomException customEx = new CustomException("002", "Error al actualizar registros");
                await HandleExceptionAsync(context, customEx);
            }
            catch (DivideByZeroException ex)
            {
                CustomException customEx = new CustomException("003", "Error de división entre 0");
                await HandleExceptionAsync(context, customEx);
            }
            catch (ArithmeticException ex)
            {
                CustomException customEx = new CustomException("004", "Error al hacer algún cálculo");
                await HandleExceptionAsync(context, customEx);
            }
            catch (Exception ex)
            {
                CustomException customEx = new CustomException("005", "Error no controlado");
                await HandleExceptionAsync(context, customEx);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, CustomException ex)
        {
            var controllerActionDescriptor = context.GetEndpoint()?.Metadata.GetMetadata<ControllerActionDescriptor>();
            InfoRequest info = _helperHttpContext.GetInfoRequest(context);
            GenericResponse error = new GenericResponse
            {
                Success = false,
                Mensaje = ex.MensajeUsuario,
                Codigo = ex.CodigoError
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;
            return context.Response.WriteAsJsonAsync(error);
        }
    }
}
