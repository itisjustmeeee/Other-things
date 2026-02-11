
// 1

/*decimal result = 0;
decimal memory = 0;

while (true)
{
    Console.Write("enter operation (+, -, *, /, %, 1/x, x^2, sqrt(x)), M+, M-, MR) or 'exit' to escape ");
    string? operation = Console.ReadLine();

    if (operation == "exit")
    {
        Console.Write("Calculator is complete");
        break;
    }

    switch (operation)
    {
        case "+":
            result = get_x() + get_y();
            Console.WriteLine($" x + y = {result}");
            break;
        case "-":
            result = get_x() - get_y();
            Console.WriteLine($" x - y = {result}");
            break;
        case "*":
            result = get_x() * get_y();
            Console.WriteLine($" x * y = {result}");
            break;
        case "/":
            decimal y = get_y();
            if (y != 0)
            {
                result = get_x() / y;
                Console.WriteLine($"x / y = {result}");
            }
            else
            {
                Console.WriteLine("division by zero");
            }
            break;
        case "%":
            decimal x = get_x();
            y = get_y();
            result = (x / y) * 100;
            Console.WriteLine($" persent {x} of {y} = {result}%");
            break;
        case "1/x":
            x = get_x();
            if (x != 0)
            {
                result = 1 / x;
                Console.WriteLine($" 1 / x = {result}");
            }
            else
            {
                Console.WriteLine("division by zero");
            }
            break;
        case "x^2":
            result = (decimal)Math.Pow((double)get_x(), 2);
            Console.WriteLine($"x^2 = {result}");
            break;
        case "sqrt(x)":
            x = get_x();
            if (x >= 0)
            {
                result = (decimal)Math.Sqrt((double)x);
                Console.WriteLine($" sqrt(x) = {result}");
            }
            else
            {
                Console.WriteLine("sqrt from negative digit");
            }
            break;
        case "M+":
            memory = result;
            break;
        case "M-":
            memory = 0;
            break;
        case "MR":
            Console.WriteLine($"memory: {memory}");
            break;
        default:
            Console.WriteLine("chose operation from list");
            break;
    }
}

decimal get_x(){
    Console.Write("enter x: ");
    decimal x = Convert.ToDecimal(Console.ReadLine());
    return x;
}
decimal get_y(){
    Console.Write("enter y: ");
    decimal y = Convert.ToDecimal(Console.ReadLine());
    return y;
}*/

// 2
/*
Console.Write("Enter the number of day of week to start month (1-mon, ..., 7-san): ");
string? day_week = Console.ReadLine();
Console.Write("Enter the day to find out weekend: ");
string? day_month = Console.ReadLine();

int result = (Convert.ToInt32(day_month) + (Convert.ToInt32(day_week) % 7)) % 7;
if (day_month == "1" | day_month == "2" | day_month == "3" | day_month == "4" | day_month == "5" | day_month == "8" | day_month == "9" | day_month == "10" | result == 1 | result == 0)
{
    Console.WriteLine("it's weekend");
}
else
{
    Console.WriteLine("it's weekday");
}
*/

// 3

/*double[] nominals = [100, 200, 500, 1000, 2000, 5000];
Console.Write("Enter the summ of money you need to get: ");
string? money = Console.ReadLine();
if (Convert.ToDouble(money) > 150000)
{
    Console.WriteLine("incorrect summ of money. You can't get more than 150000 per session");
    return;
}

Array.Sort(nominals, (a, b) => b.CompareTo(a));
double remains = Convert.ToDouble(money);
double total = 0;
Dictionary<double, double> used_money = new Dictionary<double, double>();

foreach (var nominal in nominals)
{
    used_money[nominal] = 0;
}

foreach (var nominal in nominals)
{
    double count = Math.Floor(remains / nominal);

    if (count > 0)
    {
        used_money[nominal] = count;
        total += count;
        remains -= nominal * count;
    }
}

if (remains == 0)
{
    Console.WriteLine($"Total amount of bills {total}");
    foreach (var pair in used_money)
    {
        if (pair.Value > 0)
        {
            Console.WriteLine($"{pair.Value} banknote(s) by {pair.Key}");   
        }
    }
}
else
{
    Console.WriteLine("impossible to get this summ of  money");
}*/

// Контрольная 2

// 1
/*using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

Console.WriteLine("Enter n: ");
double n = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Enter accuracy e: ");
double e = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Enter x from diapason [-1;1]: ");
double x = Convert.ToDouble(Console.ReadLine());

double summa = x;

if (x > 1 || x < -1)
{
    Console.WriteLine("Enter x from diapason [-1;1]");
}
else if (e >= 0.01 || e <= 0)
{
    Console.WriteLine("Enter e more than 0.01 and not delow 0");
}
else
{
    double k = 0;
    while (true)
    {
        k += 1;
        double next_term = (Math.Pow(-1, k)) * (Math.Pow(x, 2 * k + 1) / (2 * k + 1));
        if (Math.Abs(next_term) < e) break;
        summa += next_term;
    }
    double series_memer = (Math.Pow(-1, n - 1)) * (Math.Pow(x, (2 * (n - 1) + 1)) / (2 * (n - 1) + 1));
    Console.WriteLine($"function value: {summa}, nth member: {series_memer}");
}
*/

// 2
/*
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

Console.WriteLine("Enter number of ticket: ");
int n = Convert.ToInt32(Console.ReadLine());
int k = n;
int count_k = 0;
while (k > 0)
{
    count_k += 1;
    k /= 10;
}
int middle = count_k / 2;
int sum_of_begin = 0;
int sum_of_end = 0;
while (count_k > middle)
{
    sum_of_end += n % 10;
    n /= 10;
    count_k--;
}
while (count_k != 0)
{
    sum_of_begin += n % 10;
    n /= 10;
    count_k--;
}
if (sum_of_begin == sum_of_end)
{
    Console.WriteLine("True");
}
else
{
    Console.WriteLine("False");
}
*/
// 3

/*Console.WriteLine("Enter numerator: ");
int n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter denominator: ");
int m = Convert.ToInt32(Console.ReadLine());

if (m == 0)
{
    Console.WriteLine("Error: division by zero");
    return;
}
if (n == 0)
{
    Console.WriteLine("0");
    return;
}

int a = Math.Abs(n);
int b = Math.Abs(m);
while (a != 0 && b != 0)
{
    if (a > b)
    {
        a = a % b;
    }
    else
    {
        b = b % a;
    }
}
int node = a == 0 ? b : a;
if ((m < 0 && n > 0) || (n < 0 && m > 0))
{
    Console.WriteLine($"-{Math.Abs(Math.Min(m, n) / node)} / {Math.Abs(Math.Max(m, n) / node)}");
}
else if (m < 0 && n < 0)
{
    Console.WriteLine($"{Math.Min(Math.Abs(m), Math.Abs(n) / node)} / {Math.Max(Math.Abs(m), Math.Abs(n)) / node}");
}
else
{
    Console.WriteLine($"{Math.Abs(Math.Min(m, n) / node)} / {Math.Abs(Math.Max(m, n) / node)}");
}
*/

// 4
/*double min_bound = 0;
double max_bound = 63;

while (max_bound - min_bound != 2)
{
    Console.WriteLine($"is number more than {min_bound + Math.Floor((max_bound - min_bound) / 2)}: yes or no");
    string? answer = Console.ReadLine();
    switch (answer)
    {
        case "yes":
            min_bound += Math.Floor((max_bound - min_bound) / 2);
            break;
        case "no":
            max_bound -= Math.Floor((max_bound - min_bound) / 2);
            break;
    }
}
double result = min_bound + 1;
Console.WriteLine(result);*/

// 5
/*Console.WriteLine("Enter ml of milk");
int milk = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter ml od water");
int water = Convert.ToInt32(Console.ReadLine());

int cups_amerikano = 0;
int cups_latte = 0;
int cashe = 0;

while (true)
{
    if ((water >= 300) || (water >= 30 && milk >= 270))
    {
        Console.WriteLine("choose your drink: 1 - americano, 2 - latte ");
        int drink = Convert.ToInt32(Console.ReadLine());
        switch (drink)
        {
            case 1:
                if (water < 300) {
                    Console.WriteLine("not enough water\n");
                }
                else {
                    cups_amerikano += 1;
                    water -= 300;
                    cashe += 150;
                    Console.Write("your drink is ready\n");
                }
                break;
            case 2:
                if (water < 30) {
                    Console.WriteLine("not enough water\n");
                }
                else if (milk < 270) {
                    Console.WriteLine("not enough milk\n");
                }
                else {
                    cups_latte += 1;
                    water -= 30;
                    milk -= 270;
                    cashe += 170;
                    Console.Write("your drink is ready\n");
                }
                break;
        }
        
    }
    else
    {
        Console.Write("Report\n");
        Console.WriteLine($"ingredients left:\n water: {water} ml\n milk: {milk} ml\n cups of americano: {cups_amerikano}\n cups of latte: {cups_latte}\n total cashe: {cashe}");
        break;
    }
}*/

// 6
/*
Console.WriteLine("Enter the number of drops of bakteries ");
int n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter the number of drops of antibiotics ");
int x = Convert.ToInt32(Console.ReadLine());
int hours = 0;
int hours_ctrl = 10;

Console.WriteLine(hours);

while (x > 0 && n > 0)
{
    n *= 2;
    int killed = x * hours_ctrl;
    if (killed > n)
    {
        killed = n;
    }
    n -= killed;
    Console.WriteLine($"after {hours} hours {n} bacteries left");
    hours++;
    hours_ctrl--;
}
*/

// 7
/*
Console.WriteLine("Enter n ");
int n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter a ");
int a = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter b ");
int b = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter w ");
int w = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter h ");
int h = Convert.ToInt32(Console.ReadLine());

int max_square = w * h;
int d = 0;
while (true)
{
    if ((n * ((a + 2 * d) * (b + 2 * d))) > max_square)
    {
        Console.WriteLine($"Answer: d = {d - 1}");
        break;
    }
    else
    {
        d += 1;
    }
}*/

// 2.2

// 1
/*
using System.Data;
using System.Runtime.InteropServices.Marshalling;

Console.WriteLine("Enter number of rows for matrix 1");
int m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter number of columns for matrix 1");
int n = Convert.ToInt32(Console.ReadLine());

double[,] matrix = new double[m, n];

Console.WriteLine("Enter number of rows for matrix 2");
int x = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter number of columns for matrix2");
int y = Convert.ToInt32(Console.ReadLine());

double[,] matrix2 = new double[x, y];

Console.WriteLine("Enter the way you want to fill the matrix: from keyboard(1) or with random numbers(2)");
int way = Convert.ToInt32(Console.ReadLine());
switch (way)
{
    case 1:
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.WriteLine($"Enter element [{i + 1}{j + 1}] ");
                matrix[i, j] = Convert.ToDouble(Console.ReadLine());
            }
        }
        break;

    case 2:
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Random number = new Random();
                double element = number.Next(1, 300);
                matrix[i, j] = element;
            }
        }
        break;
}

Console.WriteLine("Enter the way you want to fill the matrix2: from keyboard(1) or with random numbers(2)");
int way2 = Convert.ToInt32(Console.ReadLine());
switch (way2)
{
    case 1:
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Console.WriteLine($"Enter element [{i+1}{j+1}] ");
                matrix2[i, j] = Convert.ToDouble(Console.ReadLine());
            }
        }
        break;

    case 2:
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Random number = new Random();
                double element = number.Next(1, 300);
                matrix2[i, j] = element;
            }
        }
        break;
}

static void PrintMatrix(double[,] matrix) 
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write(matrix[i, j].ToString("F2") + "\t");
        }
        Console.WriteLine();
    }
}

PrintMatrix(matrix);

Console.WriteLine("----------------");

PrintMatrix(matrix2);

if (m != x || n != y)
{
    Console.Write("matrixes does not have same size. matrix addition is not possible");
    Console.WriteLine();
}
else
{
    double[,] summ = new double[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            summ[i, j] = matrix[i, j] + matrix2[i, j];
        }
    }

    Console.WriteLine("summ of matrixes:");

    PrintMatrix(summ);
}

if (n != x)
{
    Console.WriteLine("number of columns in first matrix not equal to rows in second matrix. matrix multiplication is not possible");
    Console.WriteLine();
}
else
{
    double[,] mult = new double[m, y];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < y; j++)
        {
            for (int k = 0; k < x; k++)
            {
                mult[i, j] += matrix[i, k] * matrix2[k, j];
            }
        }
    }

    Console.WriteLine("multiplication of matrixes:");

    PrintMatrix(mult);
}

static double CalculateDeterminant(double[,] matrix)
{
    int n = matrix.GetLength(0);
    if (n != matrix.GetLength(1))
    {
        Console.WriteLine("number of rows in matrix is not equal to columns. impossible to get determinant");
        return 0;
    }
    if (n == 0)
    {
        Console.WriteLine("the matrix can't by empty");
        return 0;
    }

    if (n == 1) return matrix[0, 0];
    if (n == 2) return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
    double determinant = 0.0;
    for (int j = 0; j < n; j++)
    {
        determinant += matrix[0, j] * Confactor(matrix, 0, j);
    }
    return determinant;
}

static double Confactor(double[,] matrix, int row, int column)
{
    double[,] minor = GetMinor(matrix, row, column);
    return Math.Pow(-1, row + column) * CalculateDeterminant(minor);
}

static double[,] GetMinor(double[,] matrix, int excludeRow, int excludeColumn)
{
    int n = matrix.GetLength(0);
    double[,] minor = new double[n - 1, n - 1];
    int r = 0, c = 0;

    for (int i = 0; i < n; i++)
    {
        if (i == excludeRow) continue;
        c = 0;
        for (int j = 0; j < n; j++)
        {
            if (j == excludeColumn) continue;
            minor[r, c] = matrix[i, j];
            c++;
        }
        r++;
    }
    return minor;
}

Console.WriteLine("choose which matrix do you want to find the determinant of: matrix(1), matrix2(2)");
int choose = Convert.ToInt32(Console.ReadLine());
switch (choose)
{
    case 1:
        Console.WriteLine("determinant of first matrix:");
        Console.WriteLine(CalculateDeterminant(matrix));
        break;
    case 2:
        Console.WriteLine("determinant of second matrix:");
        Console.WriteLine(CalculateDeterminant(matrix2));
        break;
}

static double[,] transposeMatrix(double[,] matrix)
{
    
    if (matrix == null){
        Console.WriteLine("matrix is empty. impossible to transpose");
        return new double[0, 0];
    }
    
    int n = matrix.GetLength(0);
    int m = matrix.GetLength(1);
    double[,] trans = new double[m, n];
    
    for (int i = 0; i < m; i++){
        for (int j = 0; j < n; j++){
            trans[i, j] = matrix[j, i];
        }
    }
    return trans;
}

Console.WriteLine("Enter which matrix you want to transpose: matrix(1), matrix2(2)");
int tr = Convert.ToInt32(Console.ReadLine());
switch(tr){
    case 1:
        Console.WriteLine("transposed first matrix");
        PrintMatrix(transposeMatrix(matrix));
        break;
    case 2:
        Console.WriteLine("transposed second matrix");
        PrintMatrix(transposeMatrix(matrix2));
        break;
}

static double[,] ReverseMatrix(double[,] matrix){

    if (matrix == null || matrix.GetLength(0) == 0){
        Console.WriteLine("matrix is empty. impossible to reverse");
        return new double[0, 0];
    }
    
    int n = matrix.GetLength(0);
    if (n != matrix.GetLength(1)){
        Console.WriteLine("matrix is not square. impossible to find reverse matrix");
        return new double[0, 0];
    }
    double det = CalculateDeterminant(matrix);
    if (det == 0){
        Console.WriteLine("determinant is 0. impossible to find reverse matrix");
        return new double[0, 0];
    }
    double[,] adjugate = new double[n,n];
    for (int i = 0; i < n; i++){
        for (int j = 0; j < n; j++){
            double[,] minor = GetMinor(matrix, i, j);
            double cofactor = Math.Pow(-1, i+j) * CalculateDeterminant(minor);
            adjugate[j, i] = cofactor;
        }
    }
    
    double[,] reverse = new double[n, n];
    double invDet = 1.0 / det;
    for (int i = 0; i < n; i++){
        for (int j = 0; j < n; j++){
            reverse[i, j] = adjugate[i, j] * invDet;
        }
    }
    return reverse;
}

Console.WriteLine("Enter which matrix do you want to reverse: matrix(1), matrix(2)");
int chosen = Convert.ToInt32(Console.ReadLine());
switch(chosen){
    case 1:
        Console.WriteLine("first reverse matrix:");
        PrintMatrix(ReverseMatrix(matrix));
        break;
    case 2:
        Console.WriteLine("second reverse matrix:");
        PrintMatrix(ReverseMatrix(matrix2));
        break;
}

static double[] SolveGaus(double[,] matrix, int n)
{

    if (matrix.GetLength(0) != matrix.GetLength(1))
    {
        Console.WriteLine("matrix is not quadratic. Impossible to solve the equation");
        return new double[0];
    }
    Console.WriteLine("enter the array values");
    double[] b = new double[n];
    for (int i = 0; i < n; i++)
    {
        Console.WriteLine($"write the {i} element");
        b[i] = Convert.ToDouble(Console.ReadLine());
    }

    double[,] array = new double[n, n + 1];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            array[i, j] = matrix[i, j];
        }
        array[i, n] = b[i];
    }

    for (int i = 0; i < n; i++)
    {
        int MaxRow = i;
        for (int k = i + 1; k < n; k++)
        {
            if (Math.Abs(array[k, i]) > Math.Abs(array[MaxRow, i]))
            {
                MaxRow = k;
            }
        }

        if (MaxRow != i)
        {
            for (int k = 0; k < n + 1; k++)
            {
                double temp = array[MaxRow, k];
                array[MaxRow, k] = array[i, k];
                array[i, k] = temp;
            }
        }

        if (Math.Abs(array[i, i]) < 1e-10)
        {
            bool row_zero = true;
            for (int j = 0; j < array.GetLength(1) - 1; j++)
            {
                if (Math.Abs(array[i, j]) >= 1e-10)
                {
                    row_zero = false;
                    break;
                }
            }

            double s = array[i, array.GetLongLength(1) - 1];
            if (row_zero && Math.Abs(s) < 1e-10)
            {
                Console.WriteLine("system has an infinite number of solutions");
            }
            else if (row_zero && Math.Abs(s) >= 1e-10)
            {
                Console.WriteLine("system has zero solutions");
            }
            else
            {
                Console.WriteLine("matix is degenerated (diagonal element is close to zero)");
            }
            return new double[0];
        }

        for (int k = i + 1; k < n; k++)
        {
            double c = -array[k, i] / array[i, i];
            for (int j = i; j < n + 1; j++)
            {
                if (i == j)
                {
                    array[k, j] = 0.0;
                }
                else
                {
                    array[k, j] += c * array[i, j];
                }
            }
        }
    }
    double[] x = new double[n];
    for (int i = n - 1; i >= 0; i--)
    {
        x[i] = array[i, n] / array[i, i];
        for (int k = i - 1; k >= 0; k--)
        {
            array[k, n] -= array[k, i] * x[i];
        }
    }

    return x;

}
double[] result;
Console.WriteLine("Enter which matrix do you want to use to solve the equation: matrix(1), matrix2(2)");
int chose_equa = Convert.ToInt32(Console.ReadLine());
switch (chose_equa)
{
    case 1:
        Console.WriteLine("solving the equation");
        result = SolveGaus(matrix, n);
        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine(result[i]);
        }
        break;
    case 2:
        Console.WriteLine("solving the equation");
        result = SolveGaus(matrix2, y);
        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine(result[i]);
        }
        break;
}
*/

// контрольная работа 3
// тетрадь 3.1
// 1
/*
Console.WriteLine("enter number you want to reverse:");
int n = Convert.ToInt32(Console.ReadLine());

static int Reverse_number(int n, int save = 0)
{
    if (n % 10 != 0)
    {
        return Reverse_number(n / 10, save * 10 + n % 10);
    }
    else
    {
        return save;
    }
}

int new_numb = Reverse_number(n);
Console.Write(new_numb);
*/
// 2

Console.WriteLine("enter positive m");
int m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("enter positive n");
int n = Convert.ToInt32(Console.ReadLine());

static int Akkerman(int m, int n)
{
    if (m == 0)
    {
        return n + 1;
    }
    else if (m > 0 && n == 0)
    {
        return Akkerman(m - 1, 1);
    }
    else
    {
        return Akkerman(m - 1, Akkerman(m, n - 1));
    }
}

int result = Akkerman(m, n);
Console.Write($"Akkerman({m},{n}) = {result}");

