using MyDiary.StorageApi.Domain.Models;
using MyDiary.StorageApi.Models;
using System;
using System.Text;
using System.Web.OData.Builder;

namespace MyDiary.StorageApi.App_Start
{
    public partial class Startup
    {
        public class OData
        {
            private static string DefaultTypeNameSpace = "type";
            private static string DefaultActionNameSpace = "action";

            public static Microsoft.OData.Edm.IEdmModel GetEdmModel()
            {
                var modelBuilder = new ODataConventionModelBuilder();

                modelBuilder.ContainerName = "storageApi";
                modelBuilder.Namespace = "container";

                modelBuilder.EnableLowerCamelCase();

                #region ENTITY SETS

                var expenseEntitySet = modelBuilder.EntitySet<Expense>("expenses");

                var incomeEntitySet = modelBuilder.EntitySet<Income>("incomes");

                var usersEntitySet = modelBuilder.EntitySet<User>("users");

                #endregion

                #region ENTITY TYPES

                var expenseEntityType = modelBuilder.EntityType<Expense>();
                expenseEntityType.Namespace = DefaultTypeNameSpace;
                expenseEntityType.Name = Camelize(expenseEntityType.Name);
                expenseEntityType.HasKey<int>(x => x.ExpenseId);

                var incomeEntityType = modelBuilder.EntityType<Income>();
                incomeEntityType.Namespace = DefaultTypeNameSpace;
                incomeEntityType.Name = Camelize(incomeEntityType.Name);
                incomeEntityType.HasKey<int>(i => i.Id);
                incomeEntityType.Property(i => i.UserId);
                incomeEntityType.Property(i => i.Amount);

                var userEntityType = modelBuilder.EntityType<User>();
                userEntityType.Namespace = DefaultTypeNameSpace;
                userEntityType.Name = Camelize(userEntityType.Name);
                userEntityType.HasKey<int>(x => x.Id);

                #endregion

                #region COMPLEX TYPES

                var chartComplexType = modelBuilder.ComplexType<Chart>();
                chartComplexType.Name = Camelize(chartComplexType.Name);
                chartComplexType.Namespace = DefaultTypeNameSpace;
                chartComplexType.Property(x => x.Amount).IsRequired();

                var monthlyChartComplexType = modelBuilder.ComplexType<MonthlyChart>();
                monthlyChartComplexType.Name = Camelize(monthlyChartComplexType.Name);
                monthlyChartComplexType.Namespace = DefaultTypeNameSpace;
                monthlyChartComplexType.Property(x => x.Name).IsRequired();

                var expenseChartSummaryComplexType = modelBuilder.ComplexType<ChartSummary>();
                expenseChartSummaryComplexType.Name = Camelize(expenseChartSummaryComplexType.Name);
                expenseChartSummaryComplexType.Namespace = DefaultTypeNameSpace;

                #endregion

                #region ENUM TYPES

                var chartTypeEnumType = modelBuilder.EnumType<ChartType>();
                chartTypeEnumType.Name = Camelize(chartTypeEnumType.Name);
                chartTypeEnumType.Namespace = DefaultTypeNameSpace;

                #endregion

                #region  ACTIONS

                #region EXPENSE 

                #endregion

                #endregion

                #region FUNCTIONS

                var getYearlySummaryFunction = expenseEntityType.Collection.Function("yearlySummary");
                getYearlySummaryFunction.Namespace = "get";
                getYearlySummaryFunction.Parameter<int>("userId").OptionalParameter = false;
                getYearlySummaryFunction.Parameter<int>("noOfLatestYears").OptionalParameter = true;
                getYearlySummaryFunction.ReturnsCollection<Chart>().OptionalReturn = false;

                var getMonthlySummaryFunction = expenseEntityType.Collection.Function("monthlySummary");
                getMonthlySummaryFunction.Namespace = "get";
                getMonthlySummaryFunction.Parameter<int>("userId").OptionalParameter = false;
                getMonthlySummaryFunction.Parameter<int>("year").OptionalParameter = false;
                getMonthlySummaryFunction.Returns<ChartSummary>().OptionalReturn = false;

                var getWeeklySummaryFunction = expenseEntityType.Collection.Function("weeklySummary");
                getWeeklySummaryFunction.Namespace = "get";
                getWeeklySummaryFunction.Parameter<int>("userId").OptionalParameter = false;
                getWeeklySummaryFunction.Parameter<int>("year").OptionalParameter = false;
                getWeeklySummaryFunction.Parameter<int>("month").OptionalParameter = false;
                getWeeklySummaryFunction.ReturnsCollection<Chart>().OptionalReturn = false;


                var getInomesByFunction = incomeEntityType.Collection.Function("chartData");
                getInomesByFunction.Namespace = "get";
                getInomesByFunction.Parameter<int>("userId").OptionalParameter = false;
                getInomesByFunction.Parameter<ChartType>("type").OptionalParameter = false;
                getInomesByFunction.Parameter<string>("typeData").OptionalParameter = false;
                getInomesByFunction.Returns<ChartSummary>().OptionalReturn = true;


                var filterUsersByFunction = userEntityType.Function("by");
                filterUsersByFunction.Namespace = "filter";
                filterUsersByFunction.Parameter<string>("type").OptionalParameter = false;
                filterUsersByFunction.Returns<bool>();

                #endregion

                return modelBuilder.GetEdmModel();
            }

            private static string Camelize(string text)
            {
                if (text == null)
                {
                    throw new ArgumentNullException("text");
                }

                if (text.Length == 0)
                {
                    return text;
                }

                var stringBuilder = new StringBuilder(text);
                stringBuilder[0] = char.ToLowerInvariant(text[0]);

                return stringBuilder.ToString();
            }
        }
    }
}