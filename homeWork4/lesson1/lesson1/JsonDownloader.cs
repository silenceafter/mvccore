using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
namespace lesson1;

public class JsonDownloader
{
	public JsonDownloader()
    {
		_myClient = new HttpClient();
	}

	private HttpClient _myClient;

	public HttpClient MyClient
    {
		get => _myClient;
		set => _myClient = value;
    }

	public async Task<T> Start<T>(string link, int id)
	{		
		CancellationTokenSource tokenSource = new CancellationTokenSource();
		var task = GetRequest<T>(link, tokenSource);
		if (task.Exception != null)
		{
			//
			throw new Exception($"{task.Exception}");
		}

		//ждем выполнения задач
		try
		{
			tokenSource.CancelAfter(10000);
			_ = await task;
		}
		catch (TaskCanceledException ex)
		{
			Console.WriteLine("Выполнение задачи остановлено, ошибка: " + ex.Message);
		}
		finally
		{
			tokenSource.Dispose();
		}
		return task.Result;
	}

	public async Task<T> GetRequest<T>(string link, CancellationTokenSource tokenSource)
	{
		
		var result = (T)Activator.CreateInstance(typeof(T));
		try
		{
			HttpResponseMessage response = await _myClient.GetAsync(link, tokenSource.Token);
			response.EnsureSuccessStatusCode();//проверка                
			string responseBody = await response.Content.ReadAsStringAsync();
			result = JsonSerializer.Deserialize<T>(responseBody);
		}
		catch (HttpRequestException ex)
		{
			Console.WriteLine("Exception ", ex.Message);
		}
		return result;
	}
}