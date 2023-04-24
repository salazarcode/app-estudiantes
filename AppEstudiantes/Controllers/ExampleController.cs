using Microsoft.AspNetCore.Mvc;
using Datos;

namespace AppEstudiantes.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ExampleController : ControllerBase
	{
		public ExampleController()
		{
		}

		public class LoginInput
		{
			public string usuario { get; set; }

			public string clave { get; set; }
		}

		[HttpPost()]
		[Route("login")]
		public ActionResult Login([FromBody] LoginInput input)
		{
			var result = new JsonResult(new
			{
				usuario = input.usuario,
				clave = input.clave
			});
			return result;
		}

		[HttpPut()]
		[Route("Put")]
		public ActionResult Put([FromForm] string usuario, [FromForm] string clave)
		{
			var result = new JsonResult(new
			{
				usuario = usuario,
				clave = clave
			});
			return result;
		}

		[HttpDelete()]
		[Route("Delete")]
		public ActionResult Delete([FromForm] string usuario, [FromForm] string clave)
		{
			var result = new JsonResult(new
			{
				usuario = usuario,
				clave = clave
			});
			return result;
		}
	}
}