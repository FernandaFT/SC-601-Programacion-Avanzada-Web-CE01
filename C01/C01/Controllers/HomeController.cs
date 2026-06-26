using C01.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Data;

namespace C01.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Registro

        [HttpGet]
        public IActionResult Registro()
        {
            var model = new ReservaModel
            {
                TiposHabitaciones = ObtenerTiposHabitaciones()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Registro(ReservaModel model)
        {
            if (!ModelState.IsValid)
            {
                model.TiposHabitaciones = ObtenerTiposHabitaciones();
                return View(model);
            }

            using var context = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            var parameters = new DynamicParameters();
            parameters.Add("@NumeroHabitacion", model.NumeroHabitacion);
            parameters.Add("@MontoTotal", model.MontoTotal);
            parameters.Add("@TipoHabitacion", model.TipoHabitacion);

            var response = context.QueryFirstOrDefault<RespuestaModel>(
                "spRegistrarReserva",
                parameters);

            if (response != null && response.Codigo == 1)
            {
                TempData["Mensaje"] = response.Mensaje;
                TempData["TipoMensaje"] = "success";

                ModelState.Clear();

                return View(new ReservaModel
                {
                    TiposHabitaciones = ObtenerTiposHabitaciones()
                });
            }

            TempData["Mensaje"] = response?.Mensaje ?? "No se ha registrado la reserva correctamente.";
            TempData["TipoMensaje"] = "danger";

            model.TiposHabitaciones = ObtenerTiposHabitaciones();
            return View(model);
        }

        private List<SelectListItem> ObtenerTiposHabitaciones()
        {
            using var context = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            var tipos = context.Query<TipoHabitacionModel>(
                "spConsultarTiposHabitaciones").ToList();

            return tipos.Select(x => new SelectListItem
            {
                Value = x.TipoHabitacion.ToString(),
                Text = x.DescripcionTipo
            }).ToList();
        }

        #endregion

        #region Consultar

        [HttpGet]
        public IActionResult Consultar()
        {
            using var context = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            var reservas = context.Query<ConsultaReservaModel>(
                "spConsultarReservas").ToList();

            return View(reservas);
        }

        #endregion
    }
}