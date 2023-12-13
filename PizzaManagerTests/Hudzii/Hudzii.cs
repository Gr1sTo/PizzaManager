namespace PizzaManagerTests.Test1
{
    public class UnitTest3
    {
        
        //перевірка чи успішно додано та видалено піцу з замовлення
        [Fact]
        public void RemovePizzaFromOrder_NullPizza_ShouldThrowArgumentNullException()
        {
            // Arrange
            var orderingSystem = new PizzaOrderingSystem();
            Pizza nullPizza = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => orderingSystem.RemovePizzaFromOrder(nullPizza));
        }
        [Fact]
        
        public void AddPizzaToOrder_NullPizza_ShouldThrowArgumentNullException()
        {
            // Arrange
            var orderingSystem = new PizzaOrderingSystem();
            Pizza nullPizza = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => orderingSystem.AddPizzaToOrder(nullPizza));
        }
    }
}