using AutoMapper;
using Business.Schema_Generico.Imagenes;
using CloudinaryDotNet;
using CommonModels.Common;
using DBSenorialModels.Senorial;
using DBSenorialModels.View.Producto;
using IBusiness.Schema_Generico.Imagenes;
using IBusiness.Schema_Ventas.Productos;
using IRepository.Schema_Ventas.Productos;
using IRepository.Schema_Ventas.ProductoSucursales;
using IServices.Cloud;
using Repository.Schema_Ventas.Productos;
using Repository.Schema_Ventas.ProductoSucursales;
using RequestResponseModels.Request.CloudinaryReq;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Generico.Imagenes;
using RequestResponseModels.Request.Schema_Ventas.Productos;
using RequestResponseModels.Response.CloudinaryRes;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Generico.Imagenes;
using RequestResponseModels.Response.Schema_Ventas.Productos;
using Services.cloudinary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Schema_Ventas.Productos
{
    public class ProductoBusiness : IProductoBusiness
    {
        #region Dependency Injecction
        private readonly IProductoRepository _productoRepository;
        private readonly ICloudinaryService _cloudinary;
        private readonly IImagenesBusiness _imagenesBusiness;

        private readonly IProductoSucursalRepository _productoSucursalRepository;
        private readonly IMapper _mapper;
        public ProductoBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _productoRepository = new ProductoRepository();
            _cloudinary = new CloudinaryService();
            _imagenesBusiness = new ImagenesBusiness(mapper);
            _productoSucursalRepository = new ProductoSucursalRepository();
        }
        #endregion
        #region CRUD
        public async Task<List<ProductoResponse>> GetAll()
        {
            List<Producto> producto = await _productoRepository.GetAll();
            var response = _mapper.Map<List<ProductoResponse>>(producto);
            return response;
        }
        public async Task<ProductoResponse> GetById(int id)
        {
            Producto producto = await _productoRepository.GetById(id);
            var response = _mapper.Map<ProductoResponse>(producto);
            return response;
        }

        public async Task<ProductoResponse> Create(ProductoRequest entity)
        {
            Producto producto = _mapper.Map<Producto>(entity);
            producto = await _productoRepository.Create(producto);
            var response = _mapper.Map<ProductoResponse>(producto);
            return response;
        }

        public async Task<List<ProductoResponse>> CreateMultiple(List<ProductoRequest> list)
        {
            var producto = _mapper.Map<List<Producto>>(list);
            producto = await _productoRepository.CreateMultiple(producto);
            var response = _mapper.Map<List<ProductoResponse>>(producto);
            return response;
        }

        public async Task<ProductoResponse> Update(ProductoRequest entity)
        {
            var producto = _mapper.Map<Producto>(entity);
            producto = await _productoRepository.Update(producto);
            var response = _mapper.Map<ProductoResponse>(producto);
            return response; ;
        }

        public async Task<List<ProductoResponse>> UpdateMultiple(List<ProductoRequest> list)
        {
            var producto = _mapper.Map<List<Producto>>(list);
            producto = await _productoRepository.UpdateMultiple(producto);
            var response = _mapper.Map<List<ProductoResponse>>(producto);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _productoRepository.Delete(id);
            return result;
        }

        public async Task<List<ProductoRequest>> DeleteMultiple(List<ProductoRequest> list)
        {
            var producto = _mapper.Map<List<Producto>>(list);
            var deletedCount = await _productoRepository.DeleteMultiple(producto);
            return list;

        }

        public async Task<GenericFilterResponse<ProductoResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _productoRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<ProductoResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _productoRepository.Dispose();
        }

        #endregion
        #region UI CRUD
        public async Task<List<ProductoUiResponse>> UiGetProducto()
        {
            return await _productoRepository.UiProducto();
        }

        public async Task<ProductoUiResponse> InsertUiProducto(ProductoUiRequest request)
        {
            var existingProducto = await _productoRepository.BuscarPorNombre(request.Nombre);
            if (existingProducto != null)
            {
                throw new ArgumentException("El producto ya está registrado.");
            }

            var producto = _mapper.Map<Producto>(request);
            var productoCreado = await _productoRepository.Create(producto);
            var response = _mapper.Map<ProductoUiResponse>(productoCreado);
            return response;
        }

        public async Task<ProductoUiResponse> UpdateUiProducto(ProductoUpdateUiRequest request)
        {
            var existingProducto = await _productoRepository.BuscarPorNombre(request.Nombre);
            if (existingProducto == null)
            {
                throw new ArgumentException("El producto especificado no existe.");
            }

            _mapper.Map(request, existingProducto);
            await _productoRepository.Update(existingProducto);
            var response = _mapper.Map<ProductoUiResponse>(existingProducto);
            return response;
        }

        public async Task<bool> DeleteUiProducto(int id)
        {
            var producto = await _productoRepository.GetById(id);
            if (producto == null)
            {
                throw new ArgumentException("El producto especificado no existe.");
            }

            await _productoRepository.Delete(id);
            return true;
        }

        public async Task<GenericFilterResponse<ProductoEcommerceResponse>> FiltrarProductoAsync(GenericFilterRequest req) 
        {
            GenericFilterResponse<ProductoEcommerceResponse> res = new();

            GenericFilterResponse<VwProductoEcommerce> list =
                await _productoRepository
                .GetByFilterViewProductEcommerceAsync(req);

            foreach (var i in list.Lista)
            {
                ProductoEcommerceResponse tmp = new()
                {
                    IdProducto = i.IdProducto,
                    DetalleProducto = i.DetalleProducto,
                    NombreProducto = i.NombreProducto,
                    PrecioVenta = i.PrecioVenta,
                    RutaImagen = i.RutaImagen,
                };
                res.Lista.Add(tmp);
            }
            res.TotalRegistros = list.TotalRegistros;

            return res;
        }
        public async Task<GenericFilterResponse<ProductoDashboardResponse>> FiltrarProductoDashboardAsync(GenericFilterRequest req)
        {
            GenericFilterResponse<ProductoDashboardResponse> res = new();
            GenericFilterResponse<VwProductoDashboard> list =
                await _productoRepository
                .GetByFilterViewProductDashboardAsync(req);

            foreach(var i  in list.Lista)
            {
                ProductoDashboardResponse tmp = new()
                {
                    IdProducto = i.IdProducto,
                    Categoria = i.Categoria,
                    Derivar = i.Derivar,
                    DetalleProducto = i.DetalleProducto,
                    NombreProducto = i.NombreProducto,
                    PrecioVenta = i.PrecioVenta,
                    RutaImagen = i.RutaImagen,
                    IdCategoria = i.IdCategoria

                };
                res.Lista.Add(tmp);
            }
            res.TotalRegistros = list.TotalRegistros;

            return res;
        }
        #endregion
        #region NewProduct
        public async Task<CustomResponse> CrearNuevoProductoAsync(ProductDashRequest req)
        {
            //Registro Imagen
            UploadImageResponse resImage = await _imagenesBusiness.SubirImagenAsync(req.File);
            ImagenesRequest reqImgaen = new()
            {
                Nombre = resImage.PublicId,
                Url = resImage.Url,
            };
            ImagenesResponse resdbImagen = await _imagenesBusiness.Create(reqImgaen);
            //Registro Producto
            Producto producto = new Producto()
            {
                IdCategoria = req.IdCategoria,
                IdImg = resdbImagen.IdImg,
                Descripcion = req.Description,
                Derivar = req.Inprimir,
                PrecioVenta = req.PricioCompra,
                Nombre = req.Nombre,
            };
            producto = await _productoRepository.Create(producto);
            //Registrar Producto Sucursal
            ProductoSucursal sucursal = new()
            {
                IdUnidad = 1,
                IdCategoria = req.IdCategoria,
                IdSucursal = 1,
                IdProducto = producto.IdProducto,
                Precio = producto.PrecioVenta,
                Cantidad = 0
            };
            await _productoSucursalRepository.Create(sucursal);

            //Respuesta
            CustomResponse res = new() { Code = "201", Message = "Se registro Correctamente" };
            return res;
        }
        public async Task<CustomResponse> EditarProductoAsync(ProductEditDashRequest req)
        {
            Producto resProduct = await _productoRepository.GetById(req.IdProducto);
            ImagenesResponse Imgenes = await _imagenesBusiness.GetById(resProduct.IdImg ?? 0);
            ImagenesRequest reqImgaen = new();
            int idImagen = Imgenes.IdImg;
            if (req.Nuevo)
            {
                UploadImageResponse resImage = await _imagenesBusiness.SubirImagenAsync(req.File);
                reqImgaen.Nombre = resImage.PublicId;
                reqImgaen.Url = resImage.Url;
                ImagenesResponse imagenes = await _imagenesBusiness.Create(reqImgaen);
                idImagen = imagenes.IdImg;
            }


            resProduct.IdCategoria = req.IdCategoria;
            resProduct.IdImg = idImagen;
            resProduct.Descripcion = req.Description;
            resProduct.Derivar = req.Inprimir;
            resProduct.PrecioVenta = req.PricioCompra;
            resProduct.Nombre = req.Nombre;
            
            await _productoRepository.Update(resProduct);
            CustomResponse res = new() { Code = "201", Message = "Se Actulizo Correctamente" };
            return res;
        }
        #endregion NewProduct

    }
}
