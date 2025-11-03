resource "azurerm_resource_group" "resourcegroup" {
  name     = var.resource_group_name
  location = var.location
}

resource "azurerm_app_service_plan" "appserviceplan" {
  name                = var.service_details.name
  location            = azurerm_resource_group.resourcegroup.location
  resource_group_name = azurerm_resource_group.resourcegroup.name

  sku {
    tier = var.service_details.tier
    size = var.service_details.sku_name
  }

  kind     = var.service_details.os_type
  reserved = var.service_details.os_type == "Linux" ? true : false
}

resource "azurerm_windows_web_app" "webapp" {
  name                = var.web_app_name
  location            = azurerm_resource_group.resourcegroup.location
  resource_group_name = azurerm_resource_group.resourcegroup.name
  service_plan_id     = azurerm_app_service_plan.appserviceplan.id

  site_config {
    always_on = false

    application_stack {
      current_stack  = "dotnet"
      dotnet_version = "v4.0"
    }
  }
}
