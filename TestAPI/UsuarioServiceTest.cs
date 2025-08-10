using API.Models;
using BLL.UserBLL;
using DAL.Repositorys;
using Data.Models;
using FluentAssertions;
using Moq;

namespace TestAPI
{
    [TestClass]
    public class UsuarioServiceTest
    {
        private Mock<UsuarioRepository> _mockRepository;
        private UsuarioService _service;
        private User _testUser;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<UsuarioRepository>();
            _service = new UsuarioService(_mockRepository.Object);

            _testUser = new User
            {
                Id = 1,
                Username = "Test",
                Password = "Test",
                Estado = true,
                IdDatosPersonales = 1,
                idPerfil = 1
            };
        }

        [TestMethod]
        public async Task GetProductByIdAsync_ShouldReturnProduct_WhenExists()
        {
            // Arrange
            _mockRepository.Setup(r => r.GetByIdAsync(1))
                          .ReturnsAsync(_testUser);

            // Act
            var result = await _service.GetUsuarioConPsicologo(1);

            // Assert
            //using FluentAssertions for should and other functions
            result.Should().NotBeNull();
            //result.Id.Should().Be(1);
            //result.Username.Should().Be("Test");
            //_mockRepository.Verify(r => r.GetByIdAsync(1), Times.Once);
        }
    }
}