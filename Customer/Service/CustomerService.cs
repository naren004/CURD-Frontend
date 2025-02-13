using System.Net.Http.Json;
using Customer.Models;

public class CustomerService
{
    private readonly HttpClient _httpClient;

    public CustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Get all customers
    public async Task<List<CustomerModel>> GetCustomersAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<CustomerModel>>("https://localhost:7241/api/Customer") ?? new List<CustomerModel>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching customers: {ex.Message}");
            return new List<CustomerModel>();
        }
    }

    // Get customer by ID
    public async Task<CustomerModel?> GetCustomerByIdAsync(string id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<CustomerModel>($"https://localhost:7241/api/Customer/{id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching customer {id}: {ex.Message}");
            return null;
        }
    }

    // Add new customer
    public async Task<bool> AddCustomerAsync(CustomerModel customer)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7241/api/Customer", customer);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding customer: {ex.Message}");
            return false;
        }
    }

    // Update customer
    public async Task<bool> UpdateCustomerAsync(CustomerModel customer)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync("https://localhost:7241/api/Customer", customer);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating customer: {ex.Message}");
            return false;
        }
    }

    // Delete customer
    public async Task<bool> DeleteCustomerAsync(string id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7241/api/Customer/{id}");
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting customer {id}: {ex.Message}");
            return false;
        }
    }
    public async Task AddCustomernewAsync(CustomerModel customer)
    {
        var response = await _httpClient.PostAsJsonAsync("https://localhost:7241/api/Customer", customer);
        response.EnsureSuccessStatusCode();
    }
    //public async Task DeleteCustomerAsync(string customerId)
    //{
    //    var response = await _httpClient.DeleteAsync($"/api/Customer/{customerId}");
    //    response.EnsureSuccessStatusCode();
    //}


}
