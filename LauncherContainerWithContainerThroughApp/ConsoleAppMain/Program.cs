using System;
using Docker.DotNet;
using Docker.DotNet.Models;

class Program
{
    static async Task Main()
    {
        try
        {
            using (var client = new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock")).CreateClient())
            {
                // Launch new containers with child app
                Console.WriteLine("Enter except 'g' to start a container");

                int i = 1;
                while (Console.ReadLine() != "g")
                {
                    var containerCreateParameters = new CreateContainerParameters
                    {
                        Image = "childapp:v1",
                        Name = $"child-app-instance-{i}",
                        // Add other container configuration as needed
                    };

                    var response = await client.Containers.CreateContainerAsync(containerCreateParameters);
                    Console.WriteLine($"Container {response.ID} created successfully.");

                    // Start the container
                    await client.Containers.StartContainerAsync(response.ID, new ContainerStartParameters());
                    Console.WriteLine("Enter except 'g' to start a container");
                    i++;

                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
