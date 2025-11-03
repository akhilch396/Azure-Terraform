resource_group_name = "web-grp"
location            = "East US"
web_app_name        = "my-web-app"

service_details = {
  name     = "web-app-service-plan"
  sku_name = "F1"
  os_type  = "Windows"
}
