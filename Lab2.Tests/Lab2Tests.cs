namespace Lab2.Tests;

public class Lab2Tests
{
    [Fact]
        public void SolveTask_SimpleCase_ReturnsCorrectResult()
        {
            int[][] array = new int[][]
            {
                new int[] { 1, 1, 1 },
                new int[] { 2, 2, 2 },
                new int[] { 1, 1, 1 }
            };

            int result = TaskProcessor.SolveTask(array);

            Assert.Equal(6, result); 
        }

        [Fact]
        public void SolveTask_OneRow_ReturnsSum()
        {
            int[][] array = new int[][]
            {
                new int[] { 1, 2, 3, 4 }
            };

            int result = TaskProcessor.SolveTask(array);

            Assert.Equal(10, result);
        }

        [Fact]
        public void SolveTask_OneColumn_ReturnsSum()
        {
            int[][] array = new int[][]
            {
                new int[] { 1 },
                new int[] { 2 },
                new int[] { 3 },
                new int[] { 4 }
            };

            int result = TaskProcessor.SolveTask(array);

            Assert.Equal(10, result);
        }

        [Fact]
        public void ProcessInput_ValidInput_ReturnsCorrectMatrix()
        {
            string[] input = new string[]
            {
                "2 3",
                "1 2 3",
                "4 5 6"
            };

            var result = TaskProcessor.ProcessInput(input);

            Assert.Single(result);
            Assert.Equal(new int[][] 
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 }
            }, result[0]);
        }

        [Fact]
        public void ProcessInput_InvalidMatrixFormat_SkipsInvalidMatrix()
        {
            string[] input = new string[]
            {
                "2 3",
                "1 2 3",
                "4 5",
                "3 3",
                "1 2 3",
                "4 5 6",
                "7 8 9"
            };

            var result = TaskProcessor.ProcessInput(input);

            Assert.Single(result);
            Assert.Equal(new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 }
            }, result[0]);
        }
}