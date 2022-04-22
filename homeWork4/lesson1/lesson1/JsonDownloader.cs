using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
namespace lesson1;

/*public class JsonDownloader<T1, T2>
{
	public JsonDownloader()
    {
		_myClient = new HttpClient();
		//_tokenSource = new CancellationTokenSource();
	}

	private HttpClient _myClient;
	//private CancellationTokenSource _tokenSource;

	public HttpClient MyClient
    {
		get => _myClient;
		set => _myClient = value;
    }

	/*public CancellationTokenSource TokenSource
    {
		get => _tokenSource;
		set => _tokenSource = value;
    }*/

/*	public async Task<T1, T2> Start<T1, T2>(string link, int id)
	//public async Task<T> Start<T>(string link, int id) where T : ResponseCompany, new()
	{		
		CancellationTokenSource tokenSource = new CancellationTokenSource();
		Console.WriteLine("Получение данных:");
		//string link = $"https://www.javaniceday.com/frandom/api/companies?quantity={1}";
		var task = GetRequest<T1, T2>(link, tokenSource);
		if (task.Exception != null)
		{
			//ошибка
		}

		//ждем выполнения задач
		try
		{
			tokenSource.CancelAfter(10000);
			_ = await task;//_ = await Task.WhenAll(Tasks);
		}
		catch (TaskCanceledException ex)
		{
			Console.WriteLine("Выполнение задачи остановлено, ошибка: " + ex.Message);
		}
		finally
		{
			tokenSource.Dispose();
		}

		WriteToFile<T1, T2>(task);
		return task.Result;
	}

	public async Task<T1, T2> GetRequest<T1, T2>(string link, CancellationTokenSource tokenSource)
	//public async Task<T> GetRequest<T>(string link, CancellationTokenSource tokenSource) where T: ResponseCompany, new()//ResponseCompanies
	{
		
		//T result = new T();
		try
		{
			Console.WriteLine($"{link}");//($"https://jsonplaceholder.typicode.com/posts/{id}");
			HttpResponseMessage response = await _myClient.GetAsync(link, tokenSource.Token);//($"https://jsonplaceholder.typicode.com/posts/{id}", _tokenSource.Token);
			response.EnsureSuccessStatusCode();//проверка                
			string responseBody = await response.Content.ReadAsStringAsync();
			List<T> result1 = JsonSerializer.Deserialize<List<T>>(responseBody);
			//result = //JsonSerializer.Deserialize<List<ResponseCompanies>>(responseBody);
			result = result1.First();
		}
		catch (HttpRequestException ex)
		{
			Console.WriteLine("Exception ", ex.Message);
		}
		return result;
	}

	public bool WriteToFile<T>(Task<T> task)//ResponseCompanies
	{
		var status = true;
		try
		{
			if (task.IsCompletedSuccessfully)
			{				
				Console.WriteLine($"{task.Result}");
				/*Console.WriteLine($"{task.Result.name}");
				Console.WriteLine($"{task.Result.type}");
				Console.WriteLine($"{task.Result.displayName}\n");*/
/*			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Ошибка записи в файл: {ex.Message}");
			status = false;
		}
		return status;
	}
}*/