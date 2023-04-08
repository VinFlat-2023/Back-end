/*
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;


namespace API.Controllers
{
    [Route("api/auth")]
    public class FirebaseAuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public FirebaseAuthController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        [SwaggerOperation(Summary = "Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(request.AccessToken);

                object email;

                token.Claims.TryGetValue("email", out email);

                if (email != null)
                {
                    var result = await _userService.GetUserByEmail(email.ToString());
                    if (result != null)
                    {
                        if (!result.Status.Equals(UserEnum.Active))
                        {
                            if (StringUtils.isNotEmpty(request.DeviceToken))
                            {
                                var userDeviceFound = await _userService.GetUDByDeviceToken(request.DeviceToken);
                                if (userDeviceFound == null)
                                {
                                    var userDevice = new UserDevice
                                    {
                                        DeviceToken = request.DeviceToken,
                                        UserId = result.UserId
                                    };
                                    await _userService.AddUserDeviceInfo(userDevice);
                                }
                                else if (userDeviceFound.UserId != result.UserId)
                                {
                                    userDeviceFound.UserId = result.UserId;
                                    await _userService.UpdateUserDeviceInfo(userDeviceFound);
                                }
                            }
                            
                            var accessToken = GenerateToken(result);

                            var model = _mapper.Map<UserDTO>(result);

                            var response = new AuthResponse
                            {
                                Employee = model,
                                AccessToken = accessToken
                            };
                            return Ok(response);
                        }

                        return BadRequest("Tài khoản không khả dụng, liên hệ admin: hotro@unihome.vn");
                    }

                    return StatusCode(201, "User chưa tồn tại trong hệ thống! Chuyển đến trang đăng kí!");
                }

                return BadRequest("Mã đăng nhập không hợp lệ");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Lỗi xử lí, vui lòng thử lại");
            }
        }

        [HttpPost("logout")]
        [SwaggerOperation(Summary = "Logout for")]
        public async Task<IActionResult> Logout(string deviceToken)
        {
            try
            {
                var listUserDevice = await _userService.GetListUserDeviceByToken(deviceToken);
                
                await _userService.DeleteUserDevice(listUserDevice);

                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Lỗi xử lí, vui lòng thử lại");
            }
            
        }

        [HttpPost("register")]
        [SwaggerOperation(Summary = "Register for user")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if ((DateTimeUtils.GetCurrentDateTime().Year - request.User.DateOfBirth.Year < 17)
                && request.User.RoleCode.Equals(RoleEnum.Renter))
            {
                return BadRequest("Khách thuê phải từ 17 tuổi trở lên");
            }

            var token = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(request.AccessToken);

            object email;
            token.Claims.TryGetValue("email", out email);

            if (email == null)
            {
                return BadRequest("Mã đăng nhập không hợp lệ");
            }

            // Check duplicate email
            var userEmail = email.ToString();
            var checkUser = await _userService.GetUserByEmail(userEmail);

            if (checkUser != null)
            {
                return BadRequest($"Email đã tồn tại, không thể đăng kí");
            }

            // Check duplicate phone
            checkUser = await _userService.GetUserByPhone(request.User.Phone);
            if (checkUser != null)
            {
                return BadRequest($"Số điện thoại đã tồn tại, không thể đăng kí");
            }

            // Check duplicate citizen number
            if (!request.User.CitizenNumber.IsNullOrEmpty())
            {
                // Check citizen date and its relative
                if (request.User.CitizenNumberDate == null)
                {
                    return BadRequest("Ngày cấp CMND/CCCD không thể để trống");
                }

                if (request.User.CitizenNumberDate.Value.Year - request.User.DateOfBirth.Year <= 13)
                {
                    return BadRequest("Ngày sinh và ngày cấp CMND/CCCD không phù hợp");
                }

                checkUser = await _userService.GetUserByCitizenNumber(request.User.CitizenNumber);
                if (checkUser != null)
                {
                    return BadRequest($"CMND/CCCD đã tồn tại, không thể đăng kí");
                }
            }
            try
            {
                var newUser = new User
                {
                    Fullname = request.User.Fullname,
                    Email = userEmail,
                    DateOfBirth = request.User.DateOfBirth,
                    Image = request.User.Image,
                    Phone = request.User.Phone,
                    RoleId = request.User.RoleCode.ConvertEnumToGuid(),
                    Status = (int)UserEnum.Active,
                    UniversityId = request.User.UniversityId,
                    CitizenNumber = request.User.CitizenNumber,
                    CitizenNumberDate = request.User.CitizenNumberDate,
                    Location = request.User.Location,
                    Gender = request.User.Gender,
                };

                var result = await _userService.Register(newUser);

                if (result != null)
                {
                    if (StringUtils.isNotEmpty(request.DeviceToken))
                    {
                        var userDeviceFound = await _userService.GetUDByDeviceToken(request.DeviceToken);
                        if (userDeviceFound == null)
                        {
                            var userDevice = new UserDevice
                            {
                                DeviceToken = request.DeviceToken,
                                UserId = result.UserId
                            };
                            await _userService.AddUserDeviceInfo(userDevice);
                        }
                        else if (userDeviceFound.UserId != result.UserId)
                        {
                            userDeviceFound.UserId = result.UserId;
                            await _userService.UpdateUserDeviceInfo(userDeviceFound);
                        }
                    }

                    var userRes = await _userService.GetUserById(result.UserId);
                    
                    var userInfo = _mapper.Map<UserDTO>(userRes);
                    var accessToken = GenerateToken(userRes);
                    
                    var response = new AuthResponse
                    {
                        Employee = userInfo,
                        AccessToken = accessToken
                    };

                    return Ok(response);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Lỗi xử lí, vui lòng thử lại sau");
            }
            return StatusCode(500, "Lỗi xử lí, vui lòng thử lại sau");
        }

//          [HttpPost]
//         [Route("registerqr")]
//         [SwaggerOperation(Summary = "Register for User using QR")]
//         public async Task<IActionResult> RegisterWithQr([FromBody] RegisterRequestQR request)
//         {
//             FirebaseToken token = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(request.AccessToken);
//             Object email;
//             token.Claims.TryGetValue("email", out email);
//             var emailUserExisted = await _userService.GetUserByEmail(request.User.Email);
//             if(emailUserExisted == null)
//             {
//                 if (request.User.Email.Equals(email))
//                 {
//                     string[] info = Utils.QRReader.ReadORImage(request.User.QRPictureCitizen);
//                     UniHomeRepository.Entities.User newUser = new User
//                     {
//                         UserId = Guid.NewGuid(),
//                         Fullname = request.User.Fullname,
//                         Email = request.User.Email,
//                         Image = request.User.Image,
//                         Phone = request.User.Phone,
//                         CitizenNumber = info[0],
//                         DateOfBirth = Utils.QRReader.ConvertStringToDateTime(info[3]),
//                         Gender = Utils.QRReader.ConvertToGender(info[4]),
//                         Location = info[5],
//                         CitizenNumberDate = Utils.QRReader.ConvertStringToDateTime(info[6]),
//                         RoleId = request.User.RoleId,
//                         Status = Repository.Enums.UserEnum.Active,
//                     };
//                     var userPhoneExisted = await _userService.GetUserByPhone(newUser.Phone);
//                     if (userPhoneExisted == null)
//                     {
//                         if (newUser.CitizenNumber != null)
//                         {
//                             var userCitizenNoExist = await _userService.GetUserByCitizenNumber(newUser.CitizenNumber);
//                             if (userCitizenNoExist != null)
//                             {
//                                 return await Task.Run(() => StatusCode(StatusCodes.Status300MultipleChoices, "Duplicate Citizen ID"));
//                             }
//                         }
//
//                         var result = await _userService.Register(newUser);
//                         if (result != null)
//                         {
//
//                             var model = _mapper.Map<User>(result);
//                             var accessT = GenerateToken(model);
//                             RespondObject respond = new RespondObject
//                             {
//                                 Employee = model,
//                                 AccessToken = accessT
//                             };
//
//                             return await Task.Run(() => Ok(respond));
//
//                         }
//                         return await Task.Run(() => StatusCode(403));
//
//                     }
//                     else
//                     {
//                         return await Task.Run(() => StatusCode(StatusCodes.Status300MultipleChoices, "Duplicate Phone"));
//                     }
//
//                 }
//                 else
//                 {
//                     return await Task.Run(() => StatusCode(StatusCodes.Status300MultipleChoices, "Email in request and in Firebase response is not the same!"));
//                 }
//             }
//             return BadRequest("Duplicated Email");
//             
//         }
        private string GenerateToken(User user)
        {
            // add claim để validate theo role
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, user.Role.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
            };
            if (user.CitizenNumber != null)
            {
                claims.Add(new Claim("CitizenNumber", user.CitizenNumber));
            }

            var secretKey = Encoding.UTF8.GetBytes(AppSettings.Key);
            var symmetricSecurityKey = new SymmetricSecurityKey(secretKey);
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials: credentials);
            var currentTime = DateTimeUtils.GetCurrentDateTime();
            Console.WriteLine(AppSettings.Issuer);
            Console.WriteLine(AppSettings.Key);
            var payload = new JwtPayload(issuer: AppSettings.Issuer,
                audience: AppSettings.Issuer,
                claims: claims,
                notBefore: currentTime,
                expires: currentTime.AddHours(6)
            );

            var accessToken = new JwtSecurityToken(header: header, payload: payload);
            return tokenHandler.WriteToken(accessToken);
        }
    }
}
*/

