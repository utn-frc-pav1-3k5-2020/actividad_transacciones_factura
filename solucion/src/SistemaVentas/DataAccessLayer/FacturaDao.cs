using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVentas.Entities;
using System.Data;

namespace SistemaVentas.DataAccessLayer
{
    class FacturaDao
    {
        internal bool Create(Factura factura)
        {
            DataManager dm = new DataManager();
            try
            {
                dm.Open();
                dm.BeginTransaction();

                string sql = string.Concat("INSERT INTO [dbo].[Facturas] ",
                                            "           ([nro_factura]   ",
                                            "           ,[fecha]         ",
                                            "           ,[cliente]       ",
                                            "           ,[tipoFactura]   ",
                                            "           ,[subtotal]    ",
                                            "           ,[descuento]    ",
                                            "           ,[borrado])      ",
                                            "     VALUES                 ",
                                            "           (@nro_factura   ",
                                            "           ,@fecha          ",
                                            "           ,@cliente        ",
                                            "           ,@tipoFactura    ",
                                            "           ,@subtotal     ",
                                            "           ,@descuento     ",
                                            "           ,@borrado)       ");


                var parametros = new Dictionary<string, object>();
                parametros.Add("nro_factura", factura.NroFactura);
                parametros.Add("fecha", factura.Fecha);
                parametros.Add("cliente", factura.Cliente.IdCliente);
                parametros.Add("tipoFactura", factura.TipoFactura.IdTipoFactura);
                parametros.Add("subtotal", factura.SubTotal);
                parametros.Add("descuento", factura.Descuento);
                parametros.Add("borrado", false);
                dm.EjecutarSQL(sql, parametros);

                var newId = dm.ConsultaSQLScalar(" SELECT @@IDENTITY");
                factura.IdFactura = Convert.ToInt32(newId);


                foreach (var itemFactura in factura.FacturaDetalle)
                {
                    string sqlDetalle = string.Concat(" INSERT INTO [dbo].[FacturasDetalle] ",
                                                        "           ([id_factura]           ",
                                                        "           ,[id_producto]          ",
                                                        "           ,[precio_unitario]      ",
                                                        "           ,[cantidad]             ",
                                                        "           ,[borrado])             ",
                                                        "     VALUES                        ",
                                                        "           (@id_factura            ",
                                                        "           ,@id_producto           ",
                                                        "           ,@precio_unitario       ",
                                                        "           ,@cantidad              ",
                                                        "           ,@borrado)               ");

                    var paramDetalle = new Dictionary<string, object>();
                    paramDetalle.Add("id_factura", factura.IdFactura);
                    paramDetalle.Add("id_producto", itemFactura.IdProducto);
                    paramDetalle.Add("precio_unitario", itemFactura.PrecioUnitario);
                    paramDetalle.Add("cantidad", itemFactura.Cantidad);
                    paramDetalle.Add("borrado", false);

                    dm.EjecutarSQL(sqlDetalle, paramDetalle);
                }



                dm.Commit();

            }
            catch (Exception ex)
            {
                dm.Rollback();
                throw ex;
            }
            finally
            {
                // Cierra la conexión 
                dm.Close();
            }
            return true;
        }
    }
}
