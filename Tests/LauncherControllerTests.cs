using LauncherTestAPI.Controllers;
using LauncherTestAPI.Data;
using LauncherTestAPI.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Reflection.Emit;

namespace LauncherTestAPI.Tests {
    public class LauncherControllerTests {

        private LauncherController _controller;

        [SetUp]
        public void Setup() {
            _controller = new LauncherController(new LauncherContext(), new HttpClient());
        }

        [Test]
        public void Get_WithExpectedMessage() {
            // Arrange
            var expectedResult = "REST Back-end Challenge 20201209 Running";

            // Act
            var result = _controller.Get();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(expectedResult, okResult.Value);
        }

        [Test]
        public void GetLaunchers_WithValidPage() {
            // Arrange
            var page = 1;
            var pagingSize = 10;

            // Act
            var result = _controller.GetLaunchers(page);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void GetLaunchers_WithInvalidPage() {
            // Arrange
            var invalidPage = -1;

            // Act
            var result = _controller.GetLaunchers(invalidPage);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public void GetLauncher_WithValidId() {
            // Arrange
            var id = 1;

            // Act
            var result = _controller.GetLauncher(id);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void GetLauncher_WithNotFoundId() {
            // Arrange
            var id = -1;

            // Act
            var result = _controller.GetLauncher(id);

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

        [Test]
        public void UpdateLauncher_WithValidRequest() {
            // Arrange
            var id = 1;
            var launcher = new Launcher();

            // Act
            var result = _controller.UpdateLauncher(id, launcher);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void UpdateLauncher_WithNotFoundId() {
            // Arrange
            var id = -1;
            var launcher = new Launcher();

            // Act
            var result = _controller.UpdateLauncher(id, launcher);

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

        [Test]
        public void DeleteLauncher_WithValidRequest() {
            // Arrange
            var id = 1;
            var launcher = new Launcher();

            // Act
            var result = _controller.DeleteLauncher(id);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void DeleteLauncher_WithNotFoundId() {
            // Arrange
            var id = -1;
            var launcher = new Launcher();

            // Act
            var result = _controller.DeleteLauncher(id);

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

    }
}