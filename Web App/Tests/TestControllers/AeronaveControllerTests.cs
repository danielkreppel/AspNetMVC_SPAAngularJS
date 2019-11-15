using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.AeronaveViewModels;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using System.Collections.Generic;
using Site.Controllers;
using Moq;
using Service.Contract;
using System.Web.Http;
using System.Linq;

namespace Tests.TestControllers
{
    [TestClass]
    public class AeronaveControllerTests 
    {
        private AeronaveController _aeronaveController;
        private Mock<IAeronaveService> _aeronaveServiceMock = new Mock<IAeronaveService>();

        public AeronaveControllerTests()
        {
            _aeronaveController = new AeronaveController(_aeronaveServiceMock.Object);
        }

        [TestMethod]
        public async Task MetodoBuscarMatriculasAeronaves_RetornaLista()
        {
            var listaAeronavesMock = Builder<MatriculasAeronavesViewModel>.CreateListOfSize(3).Build();
            _aeronaveServiceMock.Setup(m => m.BuscarMatriculas()).Returns(Task.FromResult<IEnumerable<MatriculasAeronavesViewModel>>(listaAeronavesMock));

            var resultado = await _aeronaveController.BuscarMatriculasAeronaves();

            Assert.IsNotNull(resultado);

            var listaMatriculas = resultado as IEnumerable<MatriculasAeronavesViewModel>;
            Assert.IsNotNull(listaMatriculas);

            Assert.AreNotEqual(0, listaMatriculas.Count());
        }
        
    }
}
