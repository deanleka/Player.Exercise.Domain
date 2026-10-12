using PlayerExercise.Domain;
namespace Blaise.Pascal.Test
{

    public class PlayerTests
    {
        [Fact]
        public void Player_ShouldStartAtLevelOne()
        {
            // Arrange-act(chiamata del costruttore in questo caso)
            Player player = new Player("Mario");

           //
            Assert.Equal(1, player.Level);

        }

        [Fact]
        public void Player_ShouldStartWithZeroExperience()
        {
            // Arrange-act
            Player player = new Player("Mario");
            // Assert
            Assert.Equal(0, player.Experience);
        }


        [Fact]
        public void Player_ShouldStartWithFullHealth()
        {
            // Arrange-act
            Player player = new Player("Mario");
            // Assert
            Assert.Equal(100, player.Health);
        }

        [Fact]
        public void Player_ShouldStartAlive()
        {
            // Arrange-act
            Player player = new Player("Mario");
            // Assert
            Assert.True(player.IsAlive);
        }

        [Fact]

        public void Player_ShouldStartWithZeroGold()
        {
            // Arrange-act
            Player player = new Player("Mario");
            // Assert
            Assert.Equal(0, player.Gold);
        }

        [Fact]

        public void Player_ShouldGainExperienceAndLevelUp()
        {
            // Arrange
            Player player = new Player("Mario");
            // Act
            player.AddExperience(150);
            // Assert
            Assert.Equal(2, player.Level);
            Assert.Equal(50, player.Experience);
        }

        [Fact]

        public void Player_ShouldNotGainExperienceForInvalidValues()
        {
            // Arrange
            Player player = new Player("Mario");
            // Act
            player.AddExperience(0);
            player.AddExperience(-10);
            // Assert
            Assert.Equal(0, player.Experience);
        }

          [Fact]

  public void Player_ShouldTakeDamageAndDie()
  {
      // Arrange
      Player player = new Player("Mario");
      // Act
      player.TakeDamage(150);
      // Assert
      Assert.Equal(0, player.Health);
      Assert.False(player.IsAlive);
  }


  [Fact]

  public void Player_ShouldHeal()
  {
      // Arrange
      Player player = new Player("Mario");
      player.TakeDamage(50);
      // Act
      player.Heal(30);
      // Assert
      Assert.Equal(80, player.Health);
  }

  [Fact]

  public void Player_ShouldHaveValidPublicKey()
  {
      // Arrange
      Player player = new Player("Mario");
      // Assert
      Assert.NotNull(player.PublicKey);
  }


    }
}
