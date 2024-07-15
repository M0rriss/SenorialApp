using AutoMapper;
using DBSenorialModels.Senorial;
using RequestResponseModels.Request.Auth;
using RequestResponseModels.Request.Auth.Recuperacion;
using RequestResponseModels.Request.Schema_Almacen.Categorias;
using RequestResponseModels.Request.Schema_Almacen.Insumo;
using RequestResponseModels.Request.Schema_Almacen.Proveedor;
using RequestResponseModels.Request.Schema_Generico.Imagenes;
using RequestResponseModels.Request.Schema_Generico.UnidadMedicion;
using RequestResponseModels.Request.Schema_Usuarios.Persona;
using RequestResponseModels.Request.Schema_Usuarios.Roles;
using RequestResponseModels.Request.Schema_Usuarios.Usuario;
using RequestResponseModels.Request.Schema_Ventas.AperturaCaja.HistorialCaja;
using RequestResponseModels.Request.Schema_Ventas.AperturaCaja;
using RequestResponseModels.Request.Schema_Ventas.Cliente;
using RequestResponseModels.Request.Schema_Ventas.Empleados;
using RequestResponseModels.Request.Schema_Ventas.Productos;
using RequestResponseModels.Response.Auth;
using RequestResponseModels.Response.Schema_Almacen.Categorias;
using RequestResponseModels.Response.Schema_Almacen.Insumo;
using RequestResponseModels.Response.Schema_Almacen.Proveedor;
using RequestResponseModels.Response.Schema_Generico.Imagenes;
using RequestResponseModels.Response.Schema_Generico.UnidadMedicion;
using RequestResponseModels.Response.Schema_Usuarios.Persona;
using RequestResponseModels.Response.Schema_Usuarios.Roles;
using RequestResponseModels.Response.Schema_Usuarios.Usuario;
using RequestResponseModels.Response.Schema_Ventas.AperturaCaja.Historial;
using RequestResponseModels.Response.Schema_Ventas.AperturaCaja;
using RequestResponseModels.Response.Schema_Ventas.Cliente;
using RequestResponseModels.Response.Schema_Ventas.DetalleVentas;
using RequestResponseModels.Response.Schema_Ventas.Empleados;
using RequestResponseModels.Response.Schema_Ventas.Productos;
using RequestResponseModels.Response.Schema_Ventas.Ventas.Detalle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestResponseModels.Request.Schema_Ventas.AperturaCaja.Cierre;
using RequestResponseModels.Request.Schema_Ventas.MetodoPago;
using RequestResponseModels.Response.Schema_Ventas.MetodoPago;
using static RequestResponseModels.Request.Schema_Ventas.MetodoPago.MetodoPagoRequest;
using static RequestResponseModels.Response.Schema_Almacen.Categorias.CategoriaResponse;
using RequestResponseModels.Request.Schema_Almacen.DetalleInventarios;
using RequestResponseModels.Request.Schema_Almacen.Entradas;
using RequestResponseModels.Request.Schema_Almacen.Inventario;
using RequestResponseModels.Request.Schema_Produccion.Salidas;
using RequestResponseModels.Response.Schema_Almacen.DetalleInventarios;
using RequestResponseModels.Response.Schema_Almacen.Entradas;
using RequestResponseModels.Response.Schema_Almacen.Inventario;
using RequestResponseModels.Response.Schema_Produccion.Salidas;
using RequestResponseModels.Request.Schema_Ventas.DetallePedidos;
using RequestResponseModels.Request.Schema_Ventas.Pedidos;
using RequestResponseModels.Response.Schema_Ventas.DetallePedidos;
using RequestResponseModels.Response.Schema_Ventas.Pedidos;
using RequestResponseModels.Request.Schema_Ventas.DetalleVentas;
using RequestResponseModels.Request.Schema_Ventas.Ventas;
using RequestResponseModels.Response.Schema_Ventas.Ventas;
using RequestResponseModels.Request.Schema_Ventas.Mesas;
using RequestResponseModels.Response.Schema_Ventas.Mesas;

namespace UtilityAutoMapper
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {
            #region AUTHORIZATION
            CreateMap<Usuario, SignInEcommerceResponse>().ReverseMap();
            CreateMap<Usuario, SignInMobileResponse>().ReverseMap();
            CreateMap<Persona, PersonaResponse>().ReverseMap();
            CreateMap<Usuario, RestablecerPasswordMovilRequest>().ReverseMap();
            CreateMap<UsuarioResponse, LoginDashboardResponse>().ReverseMap();
            CreateMap<UsuarioResponse, LoginEcommerceResponse>().ReverseMap();
            CreateMap<UsuarioResponse, LoginMobileResponse>().ReverseMap();
            CreateMap<UsuarioResponse, LoginUserRequest>().ReverseMap();
            #endregion


            #region Schema_Almacen

            #region Categoria
            CreateMap<Categoria, CategoriaRequest>().ReverseMap();
            CreateMap<Categoria,CategoriaResponse>().ReverseMap();
            CreateMap<CategoriaRequest,CategoriaResponse>().ReverseMap();
            CreateMap<Categoria, CategoriaUiResponse>().ReverseMap();
            CreateMap<Categoria, CategoriaUpdateUiRequest>().ReverseMap();
            CreateMap<CategoriaUiRequest, Categoria>().ReverseMap();
            CreateMap<CategoriaUiRequest, CategoriaResponse>().ReverseMap();
            CreateMap<CategoriaUpdateUiRequest, CategoriaResponse>().ReverseMap();
            CreateMap<CategoriaUiRequest, Categoria>().ReverseMap();
            CreateMap<Categoria, CategoriaUiRequest>().ReverseMap();
            #endregion
            #region Insumo
            CreateMap<Insumo, InsumoRequest>().ReverseMap();
            CreateMap<Insumo, InsumoResponse>().ReverseMap();
            CreateMap<InsumoRequest, InsumoResponse>().ReverseMap();
            CreateMap<Insumo, InsumoRequest>().ReverseMap();
            CreateMap<Insumo, InsumoResponse>().ReverseMap();
            CreateMap<Insumo, InsumoUiRequest>().ReverseMap();
            CreateMap<Insumo, InsumoUiResponse>().ReverseMap();
            CreateMap<Insumo, InsumoUpdateUiRequest>().ReverseMap();
            #endregion
            #region Proveedor
            CreateMap<Proveedor, ProveedorRequest>().ReverseMap();
            CreateMap<Proveedor, ProveedorResponse>().ReverseMap();
            CreateMap<ProveedorRequest,ProveedorResponse>().ReverseMap();
            CreateMap<ProveedorUiRequest,Proveedor>().ReverseMap();
            CreateMap<ProveedorUiResponse,PersonaResponse>().ReverseMap();
            CreateMap<Proveedor, ProveedorUiResponse>().ReverseMap();
            CreateMap<Proveedor, ProveedorUiRequest>().ReverseMap();
            CreateMap<Proveedor, ProveedorUpdateUiRequest>().ReverseMap();
            CreateMap<Proveedor, PersonaResponse>().ReverseMap();
            CreateMap<Proveedor, Persona>().ReverseMap();
            CreateMap<ProveedorUiRequest, Proveedor>().ReverseMap();
            CreateMap<ProveedorUiRequest, PersonaResponse>().ReverseMap();
            CreateMap<ProveedorUiResponse,PersonaResponse>().ReverseMap();
            CreateMap<ProveedorUiRequest, Persona>().ReverseMap();
            CreateMap<ProveedorUiResponse,Persona>().ReverseMap();
            CreateMap<ProveedorUiResponse, ProveedorUiRequest>().ReverseMap();



            #endregion

            #region Inventario
            CreateMap<Inventario, InventarioRequest>().ReverseMap();
            CreateMap<Inventario, InventarioResponse>().ReverseMap();

            CreateMap<DetalleInventario, DetalleInventarioRequest>().ReverseMap();
            CreateMap<DetalleInventario, DetalleInventarioResponse>().ReverseMap();

            CreateMap<Entrada, EntradaRequest>().ReverseMap();
            CreateMap<Entrada, EntradaResponse>().ReverseMap();

            CreateMap<Salida, SalidaRequest>().ReverseMap();
            CreateMap<Salida, SalidaResponse>().ReverseMap();
            #endregion
            #endregion
            #region Schema_Generico

            #region Imagenes
            CreateMap<Imagene, ImagenesRequest>().ReverseMap();
            CreateMap<Imagene, ImagenesResponse>().ReverseMap();
            CreateMap<ImagenesRequest, ImagenesResponse>().ReverseMap();
            #endregion
            #region UnidadMedicion
            CreateMap<UnidadMedicion, UnidadMedicionRequest>().ReverseMap();
            CreateMap<UnidadMedicion, UnidadMedicionResponse>().ReverseMap();
            CreateMap<UnidadMedicionRequest, UnidadMedicionResponse>().ReverseMap();
            #endregion
            #endregion
            #region Schema_Produccion
            #endregion
            #region Schema_Usuarios
            #region Usuarios
            CreateMap<Usuario,UsuarioRequest>().ReverseMap();
            CreateMap<Usuario,UsuarioResponse>().ReverseMap();
            CreateMap<UsuarioRequest, UsuarioResponse>().ReverseMap();
            CreateMap<Usuario,UsuarioUiRequest>().ReverseMap();
            CreateMap<UsuarioUiResponse, Usuario>().ReverseMap();
            #endregion
            #region Roles
            CreateMap<Role, RolesRequest>().ReverseMap();
            CreateMap<Role, RolesResponse>().ReverseMap();
            CreateMap<RolesRequest, RolesResponse>().ReverseMap();
            #endregion
            #region Personas
            CreateMap<Persona, ClienteUiResponse>().ReverseMap();
            CreateMap<Persona, PersonaRequest>().ReverseMap();
            CreateMap<Persona, PersonaResponse>().ReverseMap();
            CreateMap<Persona, LoginEcommerceResponse>().ReverseMap();
            CreateMap<PersonaResponse, ClienteUiRequest>().ReverseMap();
            CreateMap<PersonaResponse, ClienteUpdateUiRequest>().ReverseMap();
            CreateMap<PersonaResponse, ClienteUiResponse>().ReverseMap();
            CreateMap<Persona, ClienteUiRequest>().ReverseMap();
            CreateMap<Persona, ClienteUpdateUiRequest>().ReverseMap();
            CreateMap<Persona, Cliente>().ReverseMap();
            CreateMap<Persona, ClienteUiResponse>().ReverseMap();
            CreateMap<Persona, ClienteUiRequest>().ReverseMap();
            CreateMap<Persona,ProveedorUiRequest>().ReverseMap();
            CreateMap<Persona,ProveedorUiResponse>().ReverseMap();
            CreateMap<Persona,ProveedorUpdateUiRequest>().ReverseMap();
            CreateMap<PersonaResponse,ProveedorUiRequest>().ReverseMap();
            CreateMap<PersonaResponse,ProveedorUiResponse>().ReverseMap();
            CreateMap<PersonaResponse,ProveedorUpdateUiRequest>().ReverseMap();
            CreateMap<Persona, ProveedorUiResponse>().ReverseMap();

           

            #endregion

            #endregion
            #region Schema_Ventas
            #region Cliente
            CreateMap<Cliente, ClienteRequest>().ReverseMap();
            CreateMap<Cliente, ClienteResponse>().ReverseMap();
            CreateMap<ClienteRequest, ClienteResponse>().ReverseMap();
            CreateMap<Cliente, ClienteUiRequest>().ReverseMap();
            CreateMap<Cliente, ClienteUpdateUiRequest>().ReverseMap();
            CreateMap<ClienteUiRequest, ClienteUpdateUiRequest>().ReverseMap();
            CreateMap<Cliente, LoginEcommerceResponse>().ReverseMap();
            CreateMap<ClienteRequest, ClienteUiRequest>().ReverseMap();
            CreateMap<ClienteRequest, ClienteUiResponse>().ReverseMap();
            CreateMap<ClienteResponse, ClienteUiRequest>().ReverseMap();
            CreateMap<Cliente, ClienteUiResponse>().ReverseMap();
            CreateMap<ClienteUiResponse, Persona>().ReverseMap();
            CreateMap<ClienteUiResponse, PersonaRequest>().ReverseMap();
            CreateMap<ClienteUiRequest, PersonaRequest>().ReverseMap();
            CreateMap<ClienteUiRequest, PersonaResponse>().ReverseMap();
            CreateMap<ClienteUiResponse, PersonaResponse>().ReverseMap();
            CreateMap<ClienteRequest, Cliente>().ReverseMap();
            CreateMap<ClienteUiRequest, Persona>().ReverseMap();
            CreateMap<ClienteUpdateUiRequest, Persona>().ReverseMap();

            #region Producto
            CreateMap<Producto, ProductoRequest>().ReverseMap();
            CreateMap<Producto, ProductoResponse>().ReverseMap();
            CreateMap<ProductoRequest, ProductoResponse>().ReverseMap();
            #endregion

            #endregion
            #region Empleado
            CreateMap<Empleado, EmpleadoRequest>().ReverseMap();
            CreateMap<Empleado, EmpleadoResponse>().ReverseMap();
            CreateMap<EmpleadoRequest, EmpleadoResponse>().ReverseMap();
            CreateMap<Empleado, EmpleadosUiRequest>().ReverseMap();
            CreateMap<Empleado, EmpleadosUiResponse>().ReverseMap();
            CreateMap<EmpleadosUiResponse,EmpleadosUiRequest>().ReverseMap();
            CreateMap<EmpleadosUiResponse, Persona>().ReverseMap();
            CreateMap<EmpleadosUiRequest, Persona>().ReverseMap();
            CreateMap<EmpleadosUiRequest,PersonaResponse>().ReverseMap();
            CreateMap<EmpleadosUiResponse, PersonaResponse>().ReverseMap();
            CreateMap<Empleado, Persona>().ReverseMap();


            #endregion
            #region Caja_Apertura_Cierre_Historial
            // Mapeo de AperturaCajaRequest a AperturaCaja y viceversa
            CreateMap<AperturaCajaRequest, AperturaCaja>().ReverseMap();

            // Mapeo de AperturaCaja a AperturaCajaResponse y viceversa
            CreateMap<AperturaCaja, AperturaCajaResponse>().ReverseMap();

            // Mapeo de Venta a VentaDetalleResponse y viceversa
            CreateMap<Venta, VentaDetalleResponse>().ReverseMap();

            // Mapeo de DetalleVenta a DetalleVentaResponse y viceversa
            CreateMap<DetalleVenta, DetalleVentaResponse>().ReverseMap();

            // Mapeo de HistorialAperturaRequest a HistorialAperturaResponse y viceversa
            CreateMap<HistorialAperturaRequest, HistorialAperturaResponse>().ReverseMap();

            // Mapeo de ConteoDinero a ConteoDineroResponse (si es necesario) y viceversa
            CreateMap<ConteoDinero, ConteoDineroRequest>().ReverseMap();

            // Mapeo de Usuario a UsuarioResponse (si es necesario) y viceversa
            CreateMap<Usuario, UsuarioResponse>().ReverseMap();

            // Mapeo de Empleado a EmpleadoResponse (si es necesario) y viceversa
            CreateMap<Empleado, EmpleadoResponse>().ReverseMap();

            CreateMap<AperturaCaja, AperturaCajaRequest>().ReverseMap();
            CreateMap<AperturaCaja, AperturaCajaResponse>().ReverseMap();
            CreateMap<CierreCajaRequest, ConteoDinero>().ReverseMap();
            CreateMap<Venta, VentasRequest>().ReverseMap();
            CreateMap<Venta, VentasResponse>().ReverseMap();
            CreateMap<DetalleVenta, DetalleVentaRequest>().ReverseMap();
            CreateMap<DetalleVenta, DetalleVentaResponse>().ReverseMap();
            #endregion
            #region MetodoPago
            CreateMap<MetodoPago, MetodoPagoRequest>().ReverseMap();
            CreateMap<MetodoPago, MetodoPagoResponse>().ReverseMap();
            // Mapeo de MetodoPago para UI
            CreateMap<MetodoPago, MetodoPagoUiRequest>().ReverseMap();
            CreateMap<MetodoPago, MetodoPagoUiResponse>().ReverseMap();
            CreateMap<MetodoPago, MetodoPagoUpdateUiRequest>().ReverseMap();
            #endregion
            #region Producto
            CreateMap<Producto, ProductoUiRequest>().ReverseMap();
            CreateMap<Producto, ProductoUpdateUiRequest>().ReverseMap();
            CreateMap<Producto, ProductoUiResponse>().ReverseMap();
            #endregion
            #region Pedidos
            CreateMap<Pedido, PedidoRequest>().ReverseMap();
            CreateMap<Pedido, PedidoResponse>().ReverseMap();
            CreateMap<DetallePedido, DetallePedidoRequest>().ReverseMap();
            CreateMap<DetallePedido, DetallePedidoResponse>().ReverseMap();

            #endregion
            
            #region Venta
            CreateMap<Venta, VentasRequest>().ReverseMap();
            CreateMap<Venta, VentasResponse>().ReverseMap();
            CreateMap<DetalleVenta, DetalleVentaRequest>().ReverseMap();
            CreateMap<DetalleVenta, DetalleVentaResponse>().ReverseMap();
            #endregion
            #region Mesas
            CreateMap<Mesa, MesaRequest>().ReverseMap();
            CreateMap<Mesa, MesaResponse>().ReverseMap();
            CreateMap<MesaRequest, Mesa>().ReverseMap();
            CreateMap<MesaResponse, Mesa>().ReverseMap();
            CreateMap<MesaRequest, MesaResponse>().ReverseMap();
            CreateMap<MesaResponse, MesaRequest>().ReverseMap();

            #endregion

            #endregion

        }
    }
}
