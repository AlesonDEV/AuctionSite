import * as React from 'react';
import Box from "@mui/joy/Box";
import {WelcomeSection} from "@/features/home/sections/WelcomeSection";
import {AuctionsCorousel} from "@/features/home/sections/AuctionsCorousel";
import {WhyUs} from "@/features/home/sections/WhyUs";

export const HomePage = () => {
    return (
        <Box sx={{
            padding: '0 4rem'
        }}>
            <WelcomeSection />
            <AuctionsCorousel />
            <WhyUs />
        </Box>
    );
};