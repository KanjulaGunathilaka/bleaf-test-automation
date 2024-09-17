using TechTalk.SpecFlow;
using NUnit.Framework;
using bleaf_test_automation.API;
using bleaf_test_automation.Models;
using bleaf_test_automation.Utils;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace bleaf_test_automation.StepDefinitions
{
    [Binding]
    public class CategoryApiSteps
    {
        private readonly ApiClient _apiClient;
        private RestResponse _response;
        private string _categoryId;
        private Category _category;

        public CategoryApiSteps()
        {
            _apiClient = new ApiClient();
        }

        [Given(@"I am an admin user")]
        public void GivenIAmAnAdminUser()
        {
            // Implement logic to authenticate as an admin user if needed
        }

        [Given(@"I have a new category with random name and description ""(.*)""")]
        public void GivenIHaveANewCategoryWithRandomNameAndDescription(string description)
        {
            _category = new Category { Name = RandomDataHelper.GenerateRandomCategoryName(), Description = description };
        }

        [When(@"I send a POST request to the category endpoint")]
        public async Task WhenISendAPOSTRequestToTheCategoryEndpoint()
        {
            _response = await _apiClient.PostAsync<Category>(ApiEndpoints.Categories, _category);
            var createdCategory = JsonConvert.DeserializeObject<Category>(_response.Content);
            _categoryId = createdCategory.Id.ToString();
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            Assert.That(expectedStatusCode.Equals((int)_response.StatusCode));
        }

        [Then(@"the category name should be the random name used")]
        public void ThenTheCategoryNameShouldBeTheRandomNameUsed()
        {
            var category = JsonConvert.DeserializeObject<Category>(_response.Content);
            Assert.That(_category.Name.Equals(category.Name));
        }

        [Given(@"I have an existing category with ID from the created category")]
        public void GivenIHaveAnExistingCategoryWithIDFromTheCreatedCategory()
        {
            // Use the ID from the previously created category
        }

        [Given(@"I update the category name to random name")]
        public void GivenIUpdateTheCategoryNameToRandomName()
        {
            _category.Name = RandomDataHelper.GenerateRandomCategoryName();
        }

        [When(@"I send a PUT request to the category endpoint")]
        public async Task WhenISendAPUTRequestToTheCategoryEndpoint()
        {
            _response = await _apiClient.PutAsync<Category>($"{ApiEndpoints.Categories}/{_categoryId}", _category);
        }

        [When(@"I send a DELETE request to the category endpoint")]
        public async Task WhenISendADELETERequestToTheCategoryEndpoint()
        {
            _response = await _apiClient.DeleteAsync($"{ApiEndpoints.Categories}/{_categoryId}");
        }
    }
}