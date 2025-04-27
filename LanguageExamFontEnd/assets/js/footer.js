class FooterComponent extends HTMLElement {
    connectedCallback() {
      this.innerHTML = `
        <footer id="site-footer" class="site-footer">
    <div class="footer-main typography" style="background-image: url('https://iigvietnam.com/wp-content/themes/main/assets/images/common/footer-bg.png');">
        <div class="_top">
            <div class="container_common">
                <div class="content_common">
                    <div class="_left">
                        <div class="_label">
                            <svg width="17" height="17" viewBox="0 0 17 17" fill="none">
                                <path d="M8.49212 0C5.10041 0 2.34106 2.7619 2.34106 6.15672C2.34106 10.3698 7.84566 16.5548 8.08002 16.8161C8.30015 17.0615 8.68449 17.0611 8.90422 16.8161C9.13859 16.5548 14.6432 10.3698 14.6432 6.15672C14.6431 2.7619 11.8838 0 8.49212 0ZM8.49212 9.25434C6.78567 9.25434 5.3974 7.86476 5.3974 6.15672C5.3974 4.44869 6.7857 3.05914 8.49212 3.05914C10.1985 3.05914 11.5868 4.44872 11.5868 6.15676C11.5868 7.86479 10.1985 9.25434 8.49212 9.25434Z" fill="#43A2FF"/>
                            </svg>
                            Địa chỉ văn phòng                    
                        </div>  
                        <div >
                            <div style="margin-bottom: 20px;">
                                <p class="_title">TRỤ SỞ CHÍNH</p>
                                <p><a href="https://goo.gl/maps/1KZ3Df1Ef9cdK4AC6" target="_blank">75 Giang Văn Minh, Q. Ba Đình, Hà Nội</a></p>
                            </div>
                            <div>
                                <p class="_title">ĐỊA ĐIỂM ĐĂNG KÝ THI TẠI HÀ NỘI</p>
                                <p><a href="https://maps.app.goo.gl/ni72yppKNjx534qB7" target="_blank">Đại học Công nghiệp Hà Nội</a></p>
                            </div>               
                        </div>
                    </div>
                    <div class="_center">
                        <div class="_label">
                            <svg width="17" height="13" viewBox="0 0 17 13" fill="none">
                                <path d="M15.5703 0H0.576416L8.07336 6.48401L15.6551 0.0181659C15.6273 0.00965066 15.599 0.0035835 15.5703 0Z" fill="#43A2FF"/>
                                <path d="M8.4375 7.73573C8.22502 7.91841 7.91932 7.91841 7.70685 7.73573L0 1.06885V11.5045C0 11.839 0.258191 12.1101 0.576698 12.1101H15.5706C15.8891 12.1101 16.1473 11.839 16.1473 11.5045V1.15847L8.4375 7.73573Z" fill="#43A2FF"/>
                            </svg>
                            Địa chỉ Email                    
                        </div>  
                        <div class="_content">
                            <a href="mailto:info@iigvietnam.edu.vn">info@iigvietnam.edu.vn</a>
                        </div>
                         
                       
                        <div class="_label" style="margin-top: 20px;">
                            <svg width="14" height="13" viewBox="0 0 14 13" fill="none">
                                <path d="M13.6861 10.2824L11.5241 8.26995C11.0934 7.87077 10.3803 7.8829 9.93461 8.2978L8.84534 9.31133C8.77653 9.27603 8.70529 9.23916 8.6304 9.20004C7.94254 8.84533 7.00109 8.35915 6.0104 7.43648C5.01678 6.51185 4.49391 5.63431 4.11161 4.99373C4.07127 4.92586 4.03262 4.86043 3.99445 4.79829L4.7255 4.11893L5.08492 3.78401C5.53125 3.36851 5.54356 2.70498 5.11392 2.30464L2.95184 0.291991C2.52219 -0.107791 1.80871 -0.0956627 1.36238 0.319841L0.753032 0.890203L0.769684 0.905588C0.565361 1.14823 0.394623 1.42807 0.267564 1.72986C0.150441 2.01712 0.0775199 2.29123 0.0441767 2.56592C-0.241312 4.76861 0.840232 6.7817 3.7754 9.51343C7.8327 13.2892 11.1023 13.004 11.2434 12.99C11.5506 12.9559 11.845 12.8875 12.1442 12.7794C12.4657 12.6625 12.7662 12.5039 13.0267 12.3141L13.04 12.3251L13.6573 11.7625C14.1028 11.3471 14.1156 10.6834 13.6861 10.2824Z" fill="#43A2FF"/>
                            </svg>
                            Liên hệ với chúng tôi qua                    
                        </div>  
                        <div class="_content">
                            <p>Hotline:</p>
                            <p><a href="javascript:void(0)" class="_phone">1900 636 929</a></p>
                        </div>
                    </div>
                    <div class="_right">
                        <div class="_label">
                            thời gian làm việc                    
                        </div> 
                        <div class="_content">
                            <p style="margin-bottom: 20px; !important">
                                <strong class="_title">Sáng: 08:00 - 12:00</strong><br>
                                (Thứ Hai - thứ Bảy)                        
                            </p>
                            <p >
                                <strong class="_title">Chiều: 13:30 - 17:30</strong><br>
                                (Thứ Hai - Thứ Sáu)                        
                            </p>
                        </div> 
                        <img  data-src='https://iigvietnam.com/wp-content/themes/main/assets/images/common/logo_update.svg' class='lazyload' src='data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw=='> 
                        
                    </div>
                </div>
            </div>
        </div>
        <div class="_bottom">
            Copyright by IIG Vietnam 2025. All rights reserved.
            <br>
            <span style="color: rgba(255,255,255,0.35);">Designed and Developed by <a target="_blank" style="color: rgba(255,255,255,0.35);">Twinger</a></span>
        </div>
    </div>
</footer>
      `;
    }
  }
  
customElements.define('footer-component', FooterComponent);
  