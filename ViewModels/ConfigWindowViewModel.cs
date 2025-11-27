using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Taratra.Models;
using Taratra.Services;
using System;

public partial class ConfigWindowViewModel : ObservableObject
{
    private readonly ISystemeConfigService _service;

    // Action que la View pourra assigner pour fermer la fenêtre
    public Action? CloseAction { get; set; }

    public string PeriodLibelle { get; set; } = "Trimestre";
    public string PeriodNumber { get; set; } = "3";
    public string EvaluationsText { get; set; } = "DS,Examen,Projet";

    public string ProviseurName { get; set; }
    public string EcoleName { get; set; }
    public string EcoleAdresse { get; set; }
    public ConfigWindowViewModel(ISystemeConfigService service)
    {
        _service = service;
    }

    [RelayCommand]
    private void Save()
    {
        var evaluations = EvaluationsText
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select((nom, position) => new TypeEvaluation
            {
                Nom = nom.Trim(),
                Ordre = position + 1
            })
            .ToList();

        var config = new SystemeConfig
        {
            PeriodLibelle = PeriodLibelle.Trim(),
            PeriodNumber = int.Parse(PeriodNumber),
            Evaluations = evaluations,
            ProviseurName = ProviseurName,
            EcoleName = EcoleName ,
            EcoleAdresse = EcoleAdresse

        };

        _service.SaveSystemeConfig(config);

       
        CloseAction?.Invoke();
    }
}
