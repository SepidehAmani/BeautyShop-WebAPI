﻿namespace BeautyShopDomain.DTOs;

public class ChildCategoryDTO
{
    public int Id {  get; set; }
    public int ParentId { get; set; }
    public string Name { get; set; }
}
