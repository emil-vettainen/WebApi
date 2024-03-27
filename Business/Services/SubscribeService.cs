using Business.Dtos.SubsribersDtos;
using Business.Factories;
using Business.Helper.Responses;
using Infrastructure.Repositories;

namespace Business.Services;

public class SubscribeService
{
    private readonly SubscribeRepository _subsribeRepository;


    public SubscribeService(SubscribeRepository subsribeRepository)
    {
        _subsribeRepository = subsribeRepository;

    }

    public async Task<ResponseResult> CreateAsync(CreateSubscribeDto dto)
    {
        try
        {
            if (await _subsribeRepository.ExistsAsync(x => x.Email == dto.Email))
            {
                return ResponseFactory.Exists();
            }
            var result = await _subsribeRepository.CreateAsync(SubscribeFactory.FromDto(dto));
            return result != null ? ResponseFactory.Ok() : ResponseFactory.Error();
        }
        catch (Exception)
        {
            //logger
            return ResponseFactory.Error();
        }
    }


    public async Task<ResponseResult> GetAsync()
    {
        try
        {
            var subscribers = await _subsribeRepository.GetAllAsync();
            return subscribers.Any() ? ResponseFactory.Ok(subscribers.Select(subscriber => SubscribeFactory.ToDto(subscriber)).ToList()) : ResponseFactory.NotFound();
        }
        catch (Exception)
        {
            //logger
            return ResponseFactory.Error();
        }
    }


    public async Task<ResponseResult> GetAsync(string id)
    {
        try
        {
            var subscriber = await _subsribeRepository.GetOneAsync(x => x.Id == id);
            return subscriber != null ? ResponseFactory.Ok(SubscribeFactory.ToDto(subscriber)) : ResponseFactory.NotFound();
        }
        catch (Exception)
        {
            //logger
            return ResponseFactory.Error();
        }
    }


    public async Task<ResponseResult> UpdateAsync(string id, CreateSubscribeDto dto)
    {
        try
        {
            var result = await _subsribeRepository.UpdateAsync(x => x.Id == id, SubscribeFactory.FromDto(id, dto));
            return result != null ? ResponseFactory.Ok(SubscribeFactory.ToDto(result)) : ResponseFactory.NotFound();
        }
        catch (Exception)
        {
            //logger
            return ResponseFactory.Error();
        }
    }

    public async Task<ResponseResult> DeleteAsync(string id)
    {
        try
        {
            if (!await _subsribeRepository.ExistsAsync(x => x.Id == id))
            {
                return ResponseFactory.NotFound();
            }

            var result = await _subsribeRepository.DeleteAsync(x => x.Id == id);
            return result ? ResponseFactory.Ok() : ResponseFactory.Error();

        }
        catch (Exception)
        {
            //logger
            return ResponseFactory.Error();
        }
    }





}