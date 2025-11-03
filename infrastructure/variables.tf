variable "resource_group_name" {
  type        = string
  description = "Name of the Azure resource group"
}

variable "location" {
  type        = string
  description = "Azure region for deployment"
}

variable "web_app_name" {
  type        = string
  description = "Name of the Azure Web App"
}

variable "service_details" {
  type = object({
    name     = string
    sku_name = string
    os_type  = string
  })
  description = "App Service Plan details"
}
