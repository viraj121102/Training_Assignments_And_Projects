using HRISAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRISAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly HRISAppContext _context;

        public DepartmentsController(HRISAppContext context)
        {
            _context = context;
        }

        // GET: api/<DepartmentsController>
        [HttpGet]
        public IActionResult Get()
        {
            // Method 1 for common response structure

            //DepartmentList dl = new DepartmentList();
            //try
            //{
            //    List<Department> dlist = _context.Departments.ToList();
            //    dl.AllDepartments = dlist;
            //    dl.Message = "Successfull Fetching of departments";
            //    return Ok(dl);
            //}
            //catch(Exception ex)
            //{
            //    dl.AllDepartments = new List<Department>();
            //    dl.Message = ex.Message;
            //    return Ok(dl);
            //}


            // Method 2 for common response structure
            try
            {
                var departments = _context.Departments.ToList();
                return Ok(new ApiResponse<IEnumerable<Department>>
                {
                    Success = true,
                    Message = "Departments fetched successfully",
                    Data = departments
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Message = "Error fetching departments",
                    Data = ex.Message
                });
            }
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //if(_context.Departments.Find(id) == null)
            //{
            //    return NotFound("Department not found");
            //}
            //else
            //{
            //    Department dept = _context.Departments.Find(id);
            //    return Ok(dept);
            //}



            //Department dept = _context.Departments.Find(id);
            //if (dept == null)
            //{
            //    return NotFound("Department not found");
            //} else
            //{
            //    return Ok(dept);
            //}

            // MEthod 2: Custom API Response
            
            try
            {
                var department = _context.Departments.Find(id);

                if (department == null)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Message = "Department not found",
                        Data = null
                    });
                }

                return Ok(new ApiResponse<Department>
                {
                    Success = true,
                    Message = "Department fetched successfully",
                    Data = department
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Message = "Error adding department",
                    Data = ex.Message
                });
            }
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public IActionResult Post([FromBody] Department dept)
        {
            //try
            //{
            //    _context.Departments.Add(dept);
            //    _context.SaveChanges();
            //    return "Successfully added Department.";
            //}
            //catch(Exception ex)
            //{
            //    return ex.Message;
            //}

            // Method 2 Custom API Response
            try
            {
                _context.Departments.Add(dept);
                _context.SaveChanges();

                return Ok(new ApiResponse<Department>
                {
                    Success = true,
                    Message = "Department added successfully",
                    Data = dept
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Message = "Error adding department",
                    Data = ex.Message
                });
            }
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Department dept)
        {
            //_context.Departments.Update(dept);
            //_context.SaveChanges();

            // Method 2 Custom response 
            try
            {
                var existing = _context.Departments.Find(id);
                if (existing == null)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Message = "Department not found",
                        Data = null
                    });
                }

                existing.Name = dept.Name;
                _context.SaveChanges();

                return Ok(new ApiResponse<Department>
                {
                    Success = true,
                    Message = "Department updated successfully",
                    Data = existing
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Message = "Error adding department",
                    Data = ex.Message
                });
            }
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Department dept = _context.Departments.Find(id);
            //_context.Departments.Remove(dept);
            //_context.SaveChanges();

            try
            {
                var dept = _context.Departments.Find(id);
                if (dept == null)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Message = "Department not found",
                        Data = null
                    });
                }

                _context.Departments.Remove(dept);
                _context.SaveChanges();

                return Ok(new ApiResponse<Department>
                {
                    Success = true,
                    Message = "Department deleted successfully",
                    Data = dept
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Message = "Error adding department",
                    Data = ex.Message
                });
            }
        }
    }
}
