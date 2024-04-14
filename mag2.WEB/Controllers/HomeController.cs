using AutoMapper;
using mag2.BLL.BusinessModels;
using mag2.BLL.DTO;
using mag2.BLL.Interfaces;
using mag2.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;


namespace mag2.WEB.Controllers;

public class HomeController : Controller
{
    ITaskService taskService;
    public HomeController(ITaskService serv)
    {
        taskService = serv;
    }
    public IActionResult GetNPage()
    {
        taskService.DeleteAll();
        return View();
    }
    public async Task<IActionResult> GetfPage(int N, bool switcher)
    {
        CounterMatrixA counterMatrixA = new CounterMatrixA(N);
        Complex[] MatrixA = counterMatrixA.MatrixA.ToArray();
        Matrix_A_DTO tempMatrix_A_DTO;
        for (int i = 0; i < N;)
        {
            for (int j = 0; j < N; j++)
            {
                for (int k = 0; k < N; k++, i++)
                {
                    tempMatrix_A_DTO = new Matrix_A_DTO { Id = i, Row = j + 1, Column = k + 1, RealPart = MatrixA[i].Real, ImaginaryPart = MatrixA[i].Imaginary };
                    await taskService.Matrix_A_DTO_Values.CreateWithoutSave(tempMatrix_A_DTO);
                }
            }
        }
        RandomVector_f randomVectorF = new RandomVector_f(N, !switcher);
        Complex[] Vector_f = randomVectorF.Vector_f.ToArray();
        ViewData["Switcher"] = !switcher;
        Vector_f_DTO tempvector_f_DTO;
        for (int i = 0; i < N; i++)
        {
            tempvector_f_DTO = new Vector_f_DTO { Id = i, RealPart = Vector_f[i].Real, ImaginaryPart = Vector_f[i].Imaginary };
            await taskService.Vector_f_DTO_Values.CreateWithoutSave(tempvector_f_DTO);
        }
        await taskService.Save();
        IEnumerable<Vector_f_DTO> convertVector_f_DTO = taskService.Vector_f_DTO_Values.GetAll();
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Vector_f_DTO, Vector_f_ViewModel>()).CreateMapper();
        var viewVector_f = mapper.Map<IEnumerable<Vector_f_DTO>, List<Vector_f_ViewModel>>(convertVector_f_DTO);
        return View(viewVector_f);
    }
    public IActionResult EditfPage(int? id)
    {
        if (id != null)
        {
            IEnumerable<Vector_f_DTO> convertVector_f_DTO = taskService.Vector_f_DTO_Values.GetAll().ToList();
            Vector_f_DTO? vector_f_DTO = convertVector_f_DTO.FirstOrDefault(p => p.Id == id)!;
            Vector_f_ViewModel? vector_f_ViewModel = new Vector_f_ViewModel { Id = vector_f_DTO.Id, RealPart = vector_f_DTO.RealPart, ImaginaryPart = vector_f_DTO.ImaginaryPart };
            if (vector_f_ViewModel != null)
                return View(vector_f_ViewModel);
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> EditfPage(Vector_f_ViewModel vector_f)
    {
        IEnumerable<Vector_f_DTO> convertVector_f_DTO = taskService.Vector_f_DTO_Values.GetAll();
        Vector_f_DTO? vector_f_DTO = convertVector_f_DTO.FirstOrDefault(x => x.Id == vector_f.Id);
        if (vector_f_DTO != null)
        {
            vector_f_DTO.RealPart = vector_f.RealPart;
            vector_f_DTO.ImaginaryPart = vector_f.ImaginaryPart;
            await taskService.Vector_f_DTO_Values.Update(vector_f_DTO);
        }
        convertVector_f_DTO = taskService.Vector_f_DTO_Values.GetAll();
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Vector_f_DTO, Vector_f_ViewModel>()).CreateMapper();
        var viewVector_f = mapper.Map<IEnumerable<Vector_f_DTO>, List<Vector_f_ViewModel>>(convertVector_f_DTO);
        return View("GetfPage", viewVector_f);
    }
    public async Task<IActionResult> DoImaginaryZero()
    {
        IEnumerable<Vector_f_DTO> convertVector_f_DTO = taskService.Vector_f_DTO_Values.GetAll();
        foreach (Vector_f_DTO vector_f in convertVector_f_DTO)
        {
            Vector_f_DTO? vector_f_DTO = new Vector_f_DTO { Id = vector_f.Id, RealPart = vector_f.RealPart, ImaginaryPart = 0.0 };
            await taskService.Vector_f_DTO_Values.Update(vector_f_DTO);
        }
        convertVector_f_DTO = taskService.Vector_f_DTO_Values.GetAll();
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Vector_f_DTO, Vector_f_ViewModel>()).CreateMapper();
        var viewVector_f = mapper.Map<IEnumerable<Vector_f_DTO>, List<Vector_f_ViewModel>>(convertVector_f_DTO);
        return View("GetfPage", viewVector_f);
    }
    public async Task<IActionResult> GetZeroPercentPage(bool switcher)
    {
        IEnumerable<Vector_f_DTO> vector_f_DTO = taskService.Vector_f_DTO_Values.GetAll();
        IEnumerable<Matrix_A_DTO> matrix_A_DTO = taskService.Matrix_A_DTO_Values.GetAll();
        Complex[][] A = ComplexConverter.ConvertToMatrix(matrix_A_DTO, (int)Math.Sqrt(matrix_A_DTO.Count()));
        Complex[] f = ComplexConverter.ConvertToVector_f(vector_f_DTO);
        //Complex[] solution = SistemOfEquationsSolver.SystemSolve(A, f);
        Complex[] solution = InverseDiscreteFourierTransform.SystemSolve(A, f);
        for (int i = 0; i < solution.Length; i++)
        {
            await taskService.Vector_c_DTO_Values.CreateWithoutSave(new Vector_c_DTO { Id = i + 1, RealPart = solution[i].Real, ImaginaryPart = solution[i].Imaginary });
        }
        await taskService.Save();

        IEnumerable<Vector_f_DTO> convertVector_f_DTO = taskService.Vector_f_DTO_Values.GetAll();
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Vector_f_DTO, Vector_f_ViewModel>()).CreateMapper();
        var viewVector_f = mapper.Map<IEnumerable<Vector_f_DTO>, List<Vector_f_ViewModel>>(convertVector_f_DTO);
        if (!switcher)
        {
            CreatorPicture.GetSinglPicture(viewVector_f.Select(x => x.RealPart).ToList(), viewVector_f.Select(x => x.ImaginaryPart).ToList());
        }
        else
        {
            RandomVector_f randomVectorF = new RandomVector_f(viewVector_f.Count(), !switcher);
            List<double> Vector_x = randomVectorF.Vector_X_k!.ToList();
            CreatorPicture.GetSinglPicture(Vector_x, viewVector_f.Select(x => x.RealPart).ToList(), "Равномерно распределенный набор иксов", "Значения вектора f");
        }
        ViewData["Switcher"] = switcher;
        IEnumerable<Vector_c_DTO> convertVector_c_DTO = taskService.Vector_c_DTO_Values.GetAll();
        mapper = new MapperConfiguration(cfg => cfg.CreateMap<Vector_c_DTO, Vector_c_ViewModel>()).CreateMapper();
        var viewVector_c = mapper.Map<IEnumerable<Vector_c_DTO>, List<Vector_c_ViewModel>>(convertVector_c_DTO);

        return View(viewVector_c);
    }
    public async Task<IActionResult> ShowPicturePage(string percent, bool switcher)
    {
        taskService.Vector_f_new_DTO_Values.DeleteAll();
        taskService.Vector_c_new_DTO_Values.DeleteAll();
        await taskService.Save();

        Vector_c_DTO[] convertVector_c_DTO = taskService.Vector_c_DTO_Values.GetAll().OrderBy(x => x.GetAbsolute()).ToArray();
        int N = (int)Math.Round(convertVector_c_DTO.Length / 100.0 * double.Parse(percent));
        for (int i = 0; i < N; i++)
        {
            Vector_c_new_DTO? vector_c_new_DTO = new Vector_c_new_DTO { Id = convertVector_c_DTO[i].Id, RealPart = 0, ImaginaryPart = 0 };
            await taskService.Vector_c_new_DTO_Values.CreateWithoutSave(vector_c_new_DTO);
        }
        for (int i = N; i < convertVector_c_DTO.Length; i++)
        {
            Vector_c_new_DTO? vector_c_new_DTO = new Vector_c_new_DTO { Id = convertVector_c_DTO[i].Id, RealPart = convertVector_c_DTO[i].RealPart, ImaginaryPart = convertVector_c_DTO[i].ImaginaryPart };
            await taskService.Vector_c_new_DTO_Values.CreateWithoutSave(vector_c_new_DTO);
        }
        await taskService.Save();

        IEnumerable<Vector_c_new_DTO> vector_c_new = taskService.Vector_c_new_DTO_Values.GetAll();
        IEnumerable<Matrix_A_DTO> matrix_A_DTO = taskService.Matrix_A_DTO_Values.GetAll();
        Complex[][] A = ComplexConverter.ConvertToMatrix(matrix_A_DTO, (int)Math.Sqrt(matrix_A_DTO.Count()));
        Complex[] c_new = ComplexConverter.ConvertToVector_c_new(vector_c_new);
        Complex[] f_new = MatrixAction.MatrixsProduct(A, c_new);
        for (int i = 0; i < f_new.Length; i++)
        {
            Vector_f_new_DTO? vector_f_new_DTO = new Vector_f_new_DTO { RealPart = f_new[i].Real, ImaginaryPart = f_new[i].Imaginary };
            await taskService.Vector_f_new_DTO_Values.CreateWithoutSave(vector_f_new_DTO);
        }
        await taskService.Save();

        IEnumerable<Vector_f_DTO> tempVector_f_DTO = taskService.Vector_f_DTO_Values.GetAll();
        IEnumerable<Vector_f_new_DTO> tempVector_f_new_DTO = taskService.Vector_f_new_DTO_Values.GetAll();


        if (!switcher)
        {
            CreatorPicture.GetBothPicture(tempVector_f_DTO.Select(x => x.RealPart).ToList(), tempVector_f_DTO.Select(x => x.ImaginaryPart).ToList(),
            tempVector_f_new_DTO.Select(x => x.RealPart).ToList(), tempVector_f_new_DTO.Select(x => x.ImaginaryPart).ToList());
        }
        else
        {
            RandomVector_f randomVectorF = new RandomVector_f(tempVector_f_DTO.Count(), !switcher);
            List<double> Vector_x = randomVectorF.Vector_X_k!.ToList();
            CreatorPicture.GetBothPicture(Vector_x, tempVector_f_DTO.Select(x => x.RealPart).ToList(),
            Vector_x, tempVector_f_new_DTO.Select(x => x.RealPart).ToList(), "Равномерно распределенный набор иксов", "Значения вектора f");
        }
        ViewData["Switcher"] = switcher;

        return View();
    }
}
