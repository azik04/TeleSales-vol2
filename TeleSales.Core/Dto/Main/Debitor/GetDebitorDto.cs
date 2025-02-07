﻿namespace TeleSales.Core.Dto.Main.Debitor;

public class GetDebitorDto
{
    public long Id { get; set; }
    public long StatusId { get; set; }
    public string StatusName { get; set; }
    public long? ResultId { get; set; }
    public string? ResultName { get; set; }
    public long ChannelId { get; set; }



    public string LegalName { get; set; }
    public string VOEN { get; set; }
    public DateOnly? PermissionStartDate { get; set; }
    public DateOnly? PermissionEndDate { get; set; }
    public long InvoiceNumber { get; set; }
    public string Subject { get; set; }
    public string District { get; set; }
    public string Street { get; set; }
    public string Phone { get; set; }

    public bool isExcluding {  get; set; }
    public bool isDone { get; set; }
    public string? Note { get; set; }
    public long? ExcludedBy { get; set; }
    public string? ExcludedByName { get; set; }
    public DateTime? LastStatusUpdate { get; set; }
    public DateTime? NextCall { get; set; }
    public bool isDeleted { get; set; }
    public DateTime CreateAt { get; set; }


    public decimal? TotalDebt { get; set; }
    public decimal? Year2018 { get; set; }
    public decimal? Year2019 { get; set; }
    public decimal? Year2020 { get; set; }
    public decimal? Year2021 { get; set; }
    public decimal? Year2022 { get; set; }
    public decimal? Year2023 { get; set; }


    public decimal? Month1_2024 { get; set; }
    public decimal? Month2_2024 { get; set; }
    public decimal? Month3_2024 { get; set; }
    public decimal? Month4_2024 { get; set; }
    public decimal? Month5_2024 { get; set; }
    public decimal? Month6_2024 { get; set; }
    public decimal? Month7_2024 { get; set; }
    public decimal? Month8_2024 { get; set; }
    public decimal? Month9_2024 { get; set; }
    public decimal? Month10_2024 { get; set; }
    public decimal? Month11_2024 { get; set; }
    public decimal? Month12_2024 { get; set; }


    public decimal? Month1_2025 { get; set; }
    public decimal? Month2_2025 { get; set; }
    public decimal? Month3_2025 { get; set; }
}
